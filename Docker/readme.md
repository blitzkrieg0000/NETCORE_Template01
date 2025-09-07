# A- CI&CD WORKS
**Kısaca: Push and Forget diyorum.**
</br>

*Kodlama süreçlerinde koda odaklanılmasını sağlayan ve üretilen kodun devamlı olarak devops işlemlerine tabi tutulup; aynı işin tekrar tekrar yapılması gerektiğinde, bir taraftan kodlama yapılırken bir taraftan projenin otomatik ayağa kalmasını sağlayacak yapıları kurduğumuz iş akışı sürecidir. Kısaca işini localde yap ve dağıtım sürecini unut*
</br>

*Projelerimizde fix işlemlerimizi WORKFLOW'lara döktüğümüz, 'Sürekli Entegrasyon ve Dağıtım' konuları hayat kurtarıcıdır ve zaman tasarrufu sağlar. Hatalarımızı en aza indirir ve genel geçerlilik sağlar.*


### GITHUB ACTIONS
*Projemizde github-workflow dosyaları vardır. Bu dosyalar'a yapmak istedimiz işlemleri 'yml & yaml' formatında github'ın anlayacağı dilde anlatırız.*
</br>

*Örnek olarak .github/workflows/.yml dosyalarına baktığımzda yapılacak iş prosedür olarak tek tek yazılarak komutlara dökülmüştür*

*Yapılan işin adı*
```
name: Build & Deploy To Digital Ocean Droplet
```

***

*Yapılan işin başlangıcı: Github'da şöyle bir event olduğunda...*
```
on:
  push:
    branches: none # [ main ]
    tags: none # [ 'v*.*.*' ]

  workflow_dispatch:
```

*Şu ortam değişkenleri ile...*
```
env:
  REGISTRY: ghcr.io # docker.io
  IMAGE_NAME: blitzkrieg0000/myproject  # ${{ github.repository }}
  IMAGE_TAG: 1.0.${{ github.run_number }}         # Autoincrement
  ConnectionStrings__Default: Host=aspnetcore_postgresql;Database=aspnetcore;Username=${{ secrets.POSTGRES_USER }};Password=${{ secrets.POSTGRES_PASSWORD }};Pooling=false;Timeout=300;CommandTimeout=300
```

*Yapılacak iş kısımları ve sırasıyla adımlar...*
```
name: Build & Deploy To Digital Ocean Droplet

on:
  push:
    branches: none # [ main ]
    tags: none # [ 'v*.*.*' ]

  workflow_dispatch:


env:
  REGISTRY: ghcr.io # docker.io
  IMAGE_NAME: blitzkrieg0000/myproject  # ${{ github.repository }}
  IMAGE_TAG: 1.0.${{ github.run_number }}         # Autoincrement
  ConnectionStrings__Default: Host=aspnetcore_postgresql;Database=aspnetcore;Username=${{ secrets.POSTGRES_USER }};Password=${{ secrets.POSTGRES_PASSWORD }};Pooling=false;Timeout=300;CommandTimeout=300


jobs:
  build-push:
    runs-on: ubuntu-latest


    permissions:
      contents: read
      packages: write
      id-token: write # This is used to complete the identity challenge with sigstore/fulcio when running outside of PRs.


    steps:
      - name: Checkout project to workspace
        uses: actions/checkout@v3


      - name: Install Cosign tool
        uses: sigstore/cosign-installer@main


      - name: Install docker Buildx
        uses: docker/setup-buildx-action@v1

      ...İş 1

      ...İş 2

      ...İş 3

      ...İş 4

      ...İş 5
```

**Çok uzun değil mi? Fakat bu işlemler en ufak bir kod değişikliğinde serverdaki uygulamayı ayağa kaldırmak için tekrar tekrar yapılması gereken işlemlerdi. Fakat CI&CD için geliştirilen teknolojiler sayesinde bir kaç tıklama ile işlemlerimizi gerçekleştiriyoruz.**


***

## Github Secrets: Hassas verilerin tutulması
*Github bizim için secretleri her repo için tutabilir. Örneğin bu veritabanı şifresi veya private key olabilir. Hatta github sakladığımız repositorylere ulaşmamız adına bizim için PAT(Personal Access Token) bile sağlar. Bu şekilde Private repolarımıza bile public yapmadan başka ortamlardan, kullanıcı adı ve şifre olmadan giriş yapabilmemizi sağlar. İsteğe bağlı olarak repoyu çekebilecek veya silebilecek çeşitli Fine-grained Tokenlar oluşturabiliriz.*

</br>

***

*Aslında github ın bu workflow özelliği sanal container'lardan ibaret. Github bizim adımıza içinde docker'ın bulunduğu ve bir çok linux kütüphane ve programı yükleyebileceğimiz geçici bir çalışma ortamı (RUNNER) açıyor. Ve bizde işimizi halledicek kadar bu ortamda kalıp ortamı kapatabiliyoruz ve havada uçuşan şifreler vs. ebediyen siliniyor. Binlerce kullanıcı aynı anda bu makineler ile çalışıyor...*

***İnanılmaz bir datacenter yükü ve binlerce fiziksel makine, yüzlerce datacenter ve dağıtık sistem analiziyle beraber gelen güvenlik açıklarının kapatılması; personel sayısı ve mühendislik. Ciddi bir insanlık çalışması var. Hayal gücünüzün sınırsız olması lazım vay be.***

</br>
</br>

# B- PROJE ADIMLARI
**Proje sırasıyla su şekilde ayağa kalkıyor.**
```
1-Pushlanan proje, manuel veya otomatik olarak Github actionlar ile derleniyor ve ghcr.io container registry ye kaydediliyor. Bu registy DOCKER.IO ve DOCR.IO ya göre hem bedava hem'de sınırsız. Hemde private. Daha ne.

2-Registry'ye kaydedilen projenin docker imajı, ssh komutları yardımıyla, daha önceden oluşturduğumuz "docker yüklü ve ubuntu işletim sistemi olan bulut sunucusuna bağlanılarak çektiriliyor. Yani çeşitli github-webhooklar yardımıyla, yeni proje bildirim yapmak yerine, ilgili sunucuda direkt olarak docker ghcr.io ya giriş yapılarak, private olan projemizi çektiriyoruz. Daha sonra kurulum adımlarını workflowda normal makinede çalışır gibi yazıyoruz ve işlemler tamamlanınca, daha önceden yazdığımız docker-compose.yml dosyasında olduğu gibi projemiz sunucuda ayağa kalkıyor ve hizmet vermeye başlıyor.
```

***

# HOSTING - SERVER SIDE

## 1- SSH Connection
*Host makineye parolasız bağlanmak için private key tanımlıyoruz ve saklıyoruz. Açıklama yazmayı unutmuyoruz.*</br>
*Oluşturulan key default olarak linuxta "/home/username/.ssh/id_rsa.pub" dizinine oluşuyor. cat komutu ile görüntüleyebiliriz.*
```
  $ ssh-keygen -t rsa -C "DigitalOceanAspnetcoreDroplet"
  $ cat ~/.ssh/id_rsa.pub 
```
### DigitalOcean Droplets
*Her sunucuda farklı olsa da digital ocean da, bu keyimizi "SSH keys" menüsünden kaydediyoruz. Ve bu key ile droplet(sanal makine) oluşturuyoruz.*</br>
*Eğer bu şekilde  sanal makine oluşturmamışsak manuel olarak, "~/.ssh/authorized_keys" dosyasına keyimizi kaydediyoruz. Artık bu anahtar ile gelen ssh bağlantıları kabul edilecek demektir.*</br>
**ssh bağlantısı bu komut ile kuruluyor, eğer client bilgisayarda "~/.ssh/id_rsa dosyası"; yani private key varsa bağlantı sağlanıyor:**
```
  $ ssh username@host
```
**Bağlantı kurulurken size, "serverdan gelen public key kaydedilsin mi?" diye soruyor. Bu komutlarla her zaman, interaktif bir terminalde, manuel olarak etkileşemediğimiz için kodumuzda bir düzeltme yapıyoruz, bu otomatik olarak gelen public key'i "~/.ssh/known_hosts" konumuna kaydediyor:**
```
  $ ssh -o "StrictHostKeyChecking no" username@host
```
**Birden fazla server ile uğraşıyorsak ne  yapmalıyız?**</br>
*Private key'imizi bir dosya içerisine kaydediyoruz ve bu dosyaya, "ssh" uygulamasının ulaşması için "~/.ssh/config" dosyasını oluşturuyoruz ve içerisine şunları tanımlıyoruz.*

```
Host <config_name>
    HostName <host_name>
    User <user_name>
    IdentityFile ~/.ssh/<file_name>.key
    StrictHostKeyChecking no
```
*tanımını yaptıktan sonra sadece şu komut ile servera sorunsuz şekilde bağlanabiliriz:*
```
  $ ssh <config_name>
```

## 2- Sunucu Terminaline Bağlandıktan Sonra

*Bu komutları gerçekleştiriyoruz*

**Yeni kullanıcı ekleme**
```
  $ sudo adduser <user_name>
  $ sudo usermod -aG sudo <user_name>
  $ sudo rsync --archive --chown=<user_name>:<user_name> ~/.ssh /home/<user_name>
```
**Güvenlik Duvarı: OpenSSH'a izin ver**
```
  $ sudo ufw allow OpenSSH
  $ sudo ufw enable
```
**Docker'ı root grubuna ekle(docker yüklü değilse yükleyin)**
```
  $ sudo groupadd docker
  $ sudo usermod -aG docker $USER
  $ sudo newgrp docker
```
**Install Docker Compose**
*docker-compose.yml dosyası için gerekli*
```
  $ sudo apt-get install docker-compose-plugin
```

### Ek Programlar

**Docker bash tamamlama yardımcısı (isteğe bağlı)**
```
  $ sudo apt install bash-completion
  $ sudo curl -L https://raw.githubusercontent.com/docker/compose/1.26.0-rc2/contrib/completion/bash/docker-compose -o /etc/bash_completion.d/docker-compose
  $ source ~/.bashrc
```

# 3- CI&CD İşlemlerinin Açıklanması
*Çalışma aspnetcore-6 - docker - github - digitalocean hakkın bilgi birikimine ihtiyaç duyar.*

> 1- Yazdığımız proje için 'dockerfile.yml' ve docker-compose.yml dosyalarını oluşturuyoruz.

**dockerfile.yml**
```
FROM mcr.microsoft.com/dotnet/sdk:6.0 as build-stage

WORKDIR /src
COPY . .

RUN dotnet restore
RUN dotnet build ./Onion/Presentation/UI/UI.csproj -o ./build -r linux-x64 /p:PublishReadyToRun=true /p:GenerateFullPaths=true
RUN dotnet publish ./Onion/Presentation/UI/UI.csproj -c Release -o ./publish -r linux-x64 --self-contained true --no-restore /p:PublishTrimmed=true /p:PublishReadyToRun=true /p:PublishSingleFile=true


FROM mcr.microsoft.com/dotnet/aspnet:6.0 as base
COPY --from=build-stage /src/publish /src/app
WORKDIR /src/app
RUN apt-get update &&\
    apt-get install npm -y &&\
    npm install

RUN apt-get install curl -y


EXPOSE 7094
HEALTHCHECK --interval=1m --timeout=10s CMD curl --fail http://localhost:7094 || exit 1  
CMD ["./UI"]
```

**docker-compose.yml**
```
version: '3.8'
services:
    #! CONTAINER SERVICES
    aspnetcore_postgresql:
        image: postgres:latest
        hostname: aspnetcore_postgresql
        container_name: aspnetcore_postgresql
        restart: always
        stop_grace_period: 3m30s
        shm_size: 256mb
        networks:
            - aspnetcore_network
        ports:
            - "5432:5432"
        environment:
            POSTGRES_DB: aspnetcore
            PGDATA: /var/lib/postgresql/data/pgdata
            POSTGRES_HOST_AUTH_METHOD: trust
        volumes:
            - aspnetcore_droplet_volume_postgres:/var/lib/postgresql/data
        env_file:
            - ./secrets/.env


    aspnetcore_webapp:
        image: ghcr.io/blitzkrieg0000/myproject:${PROJECT_VERSION}
        depends_on:
            - aspnetcore_postgresql
        hostname: aspnetcore_webapp
        container_name: aspnetcore_webapp
        restart: always
        environment:
            - ASPNETCORE_URLS=http://*:7094
        networks:
            - aspnetcore_network
        expose:
          - "7094"
        env_file:
            - ./secrets/.env
        volumes:
          - aspnetcore_droplet_volume_uploads:/src/app/wwwroot/data


    nginx:
        image: nginx:alpine
        hostname: 'nginx'
        container_name: nginx
        volumes:
          - ./nginx/nginx.conf:/etc/nginx/nginx.conf:ro
          - ./nginx/proxy.conf:/etc/nginx/proxy.conf:ro
          - ./nginx/logs/:/var/log/nginx/
          - ./nginx/ssl/server.crt:/etc/ssl/certs/server.crt
          - ./nginx/ssl/server.key:/etc/ssl/private/server.key
        depends_on:
            - aspnetcore_webapp
        ports: 
          - '80:80'
          - '443:443'
        restart: always
        networks:
            - aspnetcore_network


#! VOLUMES
volumes:
    aspnetcore_droplet_volume_postgres:
        driver: local
        driver_opts:
            o: bind
            type: none
            device: "/mnt/myprojectvolume/sql"

    aspnetcore_droplet_volume_uploads:
        driver: local
        driver_opts:
            o: bind
            type: none
            device: "/mnt/myprojectvolume/data"

#! NETWORK
networks:
    aspnetcore_network:
        driver: bridge
           
```

> 2- .github/workflows/ dizinine gerekli github-action dosyalarımızı yml formatında tanımlıyoruz.

**.github/workflows/deploy-digitalocean.yml**
**Bu dosya içerisine gerekli adımları yazıyoruz ve github-action sekmesinden manuel çalıştırıyoruz.**
```
name: Build & Deploy To Digital Ocean Droplet

on:
  push:
    branches: none # [ main ]
    tags: none # [ 'v*.*.*' ]

  workflow_dispatch:


env:
  REGISTRY: ghcr.io # docker.io
  IMAGE_NAME: blitzkrieg0000/myproject  # ${{ github.repository }}
  IMAGE_TAG: 1.0.${{ github.run_number }}         # Autoincrement
  ConnectionStrings__Default: Host=aspnetcore_postgresql;Database=aspnetcore;Username=${{ secrets.POSTGRES_USER }};Password=${{ secrets.POSTGRES_PASSWORD }};Pooling=false;Timeout=300;CommandTimeout=300


jobs:
  build-push:
    runs-on: ubuntu-latest


    permissions:
      contents: read
      packages: write
      id-token: write # This is used to complete the identity challenge with sigstore/fulcio when running outside of PRs.


    steps:
      - name: Checkout project to workspace
        uses: actions/checkout@v3


      - name: Install Cosign tool
        uses: sigstore/cosign-installer@main


      - name: Install docker Buildx
        uses: docker/setup-buildx-action@v1


      - name: Login container registry ${{ env.REGISTRY }}
        if: github.event_name != 'pull_request'
        uses: docker/login-action@v2
        with:
          registry: ${{ env.REGISTRY }}
          username: ${{ github.actor }}
          password: ${{ secrets.GITHUB_TOKEN }}


      - name: Install docker metadata tool
        id: meta
        uses: docker/metadata-action@v4.3.0
        with:
          images: ${{ env.REGISTRY }}/${{ env.IMAGE_NAME }}


      - name: Build and push docker image (if !PR)
        id: build-and-push
        uses: docker/build-push-action@v4
        with:
          context: WebAppOnion
          push: ${{ github.event_name != 'pull_request' }}
          tags: ${{ env.REGISTRY }}/${{ env.IMAGE_NAME }}:${{ env.IMAGE_TAG }} #! Tag: ${{ steps.meta.outputs.tags }}
          labels: ${{ steps.meta.outputs.labels }}

    
      - name: Sign the published docker image
        if: ${{ github.event_name != 'pull_request' }}
        env:
          COSIGN_EXPERIMENTAL: "true"
        run: cosign sign ${{ env.REGISTRY }}/${{ env.IMAGE_NAME }}@${{ steps.build-and-push.outputs.digest }}
        

      # - name: Login Digital Ocean
      #   uses: digitalocean/action-doctl@v2.3.0
      #   with:
      #     token: ${{ secrets.DIGITAL_OCEAN_TOKEN }}


      # - name: Command Droplet and pull ${{ env.REGISTRY }}/${{ env.IMAGE_NAME }}:${{ env.IMAGE_TAG }}
      #   run: doctl compute ssh aspnetcore --ssh-user dgh --ssh-command |
      #     export CR_PAT=${{ secrets.GITHUB_TOKEN }} &&\
      #     echo $CR_PAT | docker login ghcr.io -u ${{github.actor}} --password-stdin &&\
      #     docker swarm init &&\
      #     docker secret create POSTGRES_USER ${{ secrets.POSTGRES_USER }} &&\
      #     docker secret create POSTGRES_PASSWORD ${{ secrets.POSTGRES_PASSWORD }} &&\
      #     docker secret create ${{ env.ConnectionStrings__Default }}  &&\
      #     docker pull ${{ env.REGISTRY }}/${{ env.IMAGE_NAME }}@${{ steps.build-and-push.outputs.digest }}


      - name: Configure SSH
        run: |
          mkdir -p ~/.ssh/
          echo "$SSH_KEY" > ~/.ssh/digitalocean.key
          chmod 600 ~/.ssh/digitalocean.key
          cat >>~/.ssh/config <<END
          Host digitalocean
            HostName $SSH_HOST
            User $SSH_USER
            IdentityFile ~/.ssh/digitalocean.key
            StrictHostKeyChecking no
          END
        env:
          SSH_USER: ${{ secrets.SSH_USER }}
          SSH_KEY: ${{ secrets.SSH_KEY }}
          SSH_HOST: ${{ secrets.SSH_HOST }}


      - name: Droplet - Login ghrc.io
        run: ssh digitalocean 'docker login ghcr.io -u ${{github.actor}} --password ${{ secrets.GITHUB_TOKEN }}'
  
      
      - name: Droplet - Pull Latest Image
        run: ssh digitalocean 'docker pull ${{ env.REGISTRY }}/${{ env.IMAGE_NAME }}@${{ steps.build-and-push.outputs.digest }}'

      # Geçici olarak tüm server aşağı indirilecek
      - name: Droplet - Docker Compose Down - Temporary
        run: ssh digitalocean 'docker compose down -v | echo ""'

      - name: Droplet - Send Docker Compose File
        run: rsync -avuz -e "ssh -i ~/.ssh/digitalocean.key" ./Docker/docker-compose.yml dgh@dghenerji.xyz:~/

      - name: Droplet - Send Nginx Configurations
        run: rsync -avuz -e "ssh -i ~/.ssh/digitalocean.key" ./Docker/nginx dgh@dghenerji.xyz:~/

      - name: Droplet - Create Secrets and Required Things
        run: |
          ssh digitalocean 'mkdir -p /mnt/myprojectvolume/sql | echo "File Exist Ok"'
          ssh digitalocean 'mkdir secrets | echo "File exist, ok"'
          ssh digitalocean 'echo "POSTGRES_USER=${{ secrets.POSTGRES_USER }}" > ./secrets/.env'
          ssh digitalocean 'echo "POSTGRES_PASSWORD=${{ secrets.POSTGRES_PASSWORD }}" >> ./secrets/.env'
          ssh digitalocean 'echo "ConnectionStrings__Default=${{ env.ConnectionStrings__Default }}" >> ./secrets/.env'

      - name: Droplet - Docker Compose Up
        run: ssh digitalocean 'export PROJECT_VERSION=${{env.IMAGE_TAG}} && docker compose up -d --build'

      # - name: Droplet - Clean Up
      #   run: ssh digitalocean 'rm -rf ./secrets'
```
**Bu dosya içindeki bazı komutlar şöyle:**

a- İlk olarak dockerfile.yml dosyamızı çalıştırarak github'ın bize otomatik açtığı runner'da docker imajımızı oluşturuyoruz

b- Daha sonra oluşan imaja version bilgisini "tag" leyip, imajın imzasını çıkartıyoruz ve ghcr.io container registry'sine kaydediyoruz.

c- Projemizi ayağa kaldıracağımız bilgisayara, daha önce "github secrets" menüsüne koyduğumuz ayarlar yardımıyla ssh ile bağlanarak, "docker'ın ghcr.io ya bağlanması için PAT tokenimizi gönderiyoruz."

d- Host makineye bu imajı "docker pull" edip çekmesini istiyoruz.

e- rsync komutu ile docker-compose.yml dosyamızı, gerekli ENV'leri ya da secretleri, nginx dosyaları vb. ayar dosyalarını göndererek, docker'ı konfigure etmesini ve sistemi ayağa kaldırmasını söylüyoruz.

Ayağa kalkan docker nginx sunucusu yardımıyla dış dünyaya, programımızı açıyor. En temel olarak bu iş böyle yürüyor. Github-WebHooklar'ı kullanarak, daha önceden konfigure ettiğimiz sistemi de ayağa kaldırabiliriz. Bunun için webhookları dinleyen bir python programı yazmamız ve ilgili repo güncellendiğini githubdan haber alınca, docker pull yapan bir programa ihtiyacımız var. Bu da başka bir senaryo. Senaryolar arttırılabilir....


**Ek Komutlar**
*ghcr.io 'a giriş yapmak için*
```
  $ export CR_PAT=<YOUR_TOKEN>
  $ echo $CR_PAT | docker login ghcr.io -u <github_username> --password-stdin

```
