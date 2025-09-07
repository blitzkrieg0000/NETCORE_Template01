CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;


DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230601223352_Migration01') THEN
    CREATE TABLE "ApplicationMenu" (
        "Id" uuid NOT NULL,
        "Name" text NOT NULL,
        "CreatedTime" timestamp with time zone NOT NULL,
        "ModifiedTime" timestamp with time zone NOT NULL,
        "DeletedTime" timestamp with time zone NOT NULL,
        "IsPersistent" boolean NOT NULL,
        "Active" boolean NOT NULL,
        CONSTRAINT "PK_ApplicationMenu" PRIMARY KEY ("Id")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230601223352_Migration01') THEN
    CREATE TABLE "ApplicationRole" (
        id uuid NOT NULL,
        name text NULL,
        created_time timestamp with time zone NOT NULL DEFAULT ((CURRENT_TIMESTAMP AT TIME ZONE 'UTC'::text)),
        modified_time timestamp with time zone NOT NULL,
        deleted_time timestamp with time zone NOT NULL,
        is_persistent boolean NOT NULL,
        active boolean NOT NULL DEFAULT (true),
        CONSTRAINT "PK_ApplicationRole" PRIMARY KEY (id)
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230601223352_Migration01') THEN
    CREATE TABLE "ApplicationUser" (
        id uuid NOT NULL,
        name text NULL,
        normalized_name text NULL,
        user_name text NOT NULL,
        email text NULL,
        email_approved boolean NOT NULL,
        phone_number text NULL,
        phone_number_approved boolean NOT NULL,
        password text NULL,
        gender text NOT NULL DEFAULT 'Unspecified',
        description text NULL,
        two_factor_enabled boolean NOT NULL,
        lockout_end_date_utc timestamp with time zone NOT NULL,
        lockout_enabled boolean NOT NULL,
        access_failed_count bigint NOT NULL,
        "RefreshToken" text NULL,
        refresh_token_end_date timestamp with time zone NULL,
        security_stamp_date timestamp with time zone NOT NULL,
        created_time timestamp with time zone NOT NULL DEFAULT ((CURRENT_TIMESTAMP AT TIME ZONE 'UTC'::text)),
        modified_time timestamp with time zone NOT NULL,
        deleted_time timestamp with time zone NOT NULL,
        is_persistent boolean NOT NULL,
        active boolean NOT NULL DEFAULT (true),
        CONSTRAINT "PK_ApplicationUser" PRIMARY KEY (id)
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230601223352_Migration01') THEN
    CREATE TABLE "CooperativeCategory" (
        id uuid NOT NULL,
        name text NOT NULL,
        created_time timestamp with time zone NOT NULL DEFAULT (((CURRENT_TIMESTAMP AT TIME ZONE 'UTC'::text) AT TIME ZONE 'UTC'::text)),
        modified_time timestamp with time zone NOT NULL,
        deleted_time timestamp with time zone NOT NULL,
        "IsPersistent" boolean NOT NULL,
        "Active" boolean NOT NULL,
        CONSTRAINT "PK_CooperativeCategory" PRIMARY KEY (id)
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230601223352_Migration01') THEN
    CREATE TABLE "File" (
        "Id" uuid NOT NULL,
        "FileName" text NULL,
        "Path" text NULL,
        "ThumbnailPath" text NULL,
        "StoragePath" text NULL,
        "Length" bigint NULL,
        "Description" text NULL,
        "MetaData" text NULL,
        "IsPersistent" boolean NOT NULL,
        "Discriminator" text NOT NULL,
        "Price" numeric NULL,
        created_time timestamp with time zone NOT NULL DEFAULT (((CURRENT_TIMESTAMP AT TIME ZONE 'UTC'::text) AT TIME ZONE 'UTC'::text)),
        deleted_time timestamp with time zone NOT NULL,
        "Active" boolean NOT NULL,
        CONSTRAINT "PK_File" PRIMARY KEY ("Id")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230601223352_Migration01') THEN
    CREATE TABLE "GrantSupportCategory" (
        id uuid NOT NULL,
        name text NULL,
        created_time timestamp with time zone NOT NULL DEFAULT (((CURRENT_TIMESTAMP AT TIME ZONE 'UTC'::text) AT TIME ZONE 'UTC'::text)),
        modified_time timestamp with time zone NOT NULL,
        deleted_time timestamp with time zone NOT NULL,
        "IsPersistent" boolean NOT NULL,
        "Active" boolean NOT NULL,
        CONSTRAINT "PK_GrantSupportCategory" PRIMARY KEY (id)
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230601223352_Migration01') THEN
    CREATE TABLE "NewsAnnouncementCategory" (
        id uuid NOT NULL DEFAULT (gen_random_uuid()),
        name text NULL,
        created_time timestamp with time zone NOT NULL DEFAULT (((CURRENT_TIMESTAMP AT TIME ZONE 'UTC'::text) AT TIME ZONE 'UTC'::text)),
        modified_time timestamp with time zone NOT NULL,
        deleted_time timestamp with time zone NOT NULL,
        "IsPersistent" boolean NOT NULL,
        "Active" boolean NOT NULL,
        CONSTRAINT "PK_NewsAnnouncementCategory" PRIMARY KEY (id)
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230601223352_Migration01') THEN
    CREATE TABLE "ProductGrowingSuggestionCategory" (
        id uuid NOT NULL,
        name text NOT NULL,
        created_time timestamp with time zone NOT NULL DEFAULT (((CURRENT_TIMESTAMP AT TIME ZONE 'UTC'::text) AT TIME ZONE 'UTC'::text)),
        modified_time timestamp with time zone NOT NULL,
        deleted_time timestamp with time zone NOT NULL,
        "IsPersistent" boolean NOT NULL,
        "Active" boolean NOT NULL,
        CONSTRAINT "PK_ProductGrowingSuggestionCategory" PRIMARY KEY (id)
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230601223352_Migration01') THEN
    CREATE TABLE "ApplicationEndpoint" (
        "Id" uuid NOT NULL,
        "ActionType" text NOT NULL,
        "HttpType" text NOT NULL,
        "Definition" text NOT NULL,
        "Code" text NOT NULL,
        "MenuId" uuid NOT NULL,
        "CreatedTime" timestamp with time zone NOT NULL,
        "ModifiedTime" timestamp with time zone NOT NULL,
        "DeletedTime" timestamp with time zone NOT NULL,
        "IsPersistent" boolean NOT NULL,
        "Active" boolean NOT NULL,
        CONSTRAINT "PK_ApplicationEndpoint" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_ApplicationEndpoint_ApplicationMenu_MenuId" FOREIGN KEY ("MenuId") REFERENCES "ApplicationMenu" ("Id") ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230601223352_Migration01') THEN
    CREATE TABLE "ApplicationUserClaim" (
        id uuid NOT NULL,
        user_id uuid NOT NULL,
        claim_type text NULL,
        claim_value text NULL,
        created_time timestamp with time zone NOT NULL DEFAULT ((CURRENT_TIMESTAMP AT TIME ZONE 'UTC'::text)),
        modified_time timestamp with time zone NOT NULL,
        deleted_time timestamp with time zone NOT NULL,
        is_persistent boolean NOT NULL,
        active boolean NOT NULL DEFAULT (true),
        CONSTRAINT "PK_ApplicationUserClaim" PRIMARY KEY (id),
        CONSTRAINT applicationuserclaim_fk FOREIGN KEY (user_id) REFERENCES "ApplicationUser" (id)
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230601223352_Migration01') THEN
    CREATE TABLE "ApplicationUserLogin" (
        id uuid NOT NULL,
        user_id uuid NOT NULL,
        login_provider text NULL,
        provider_key text NULL,
        created_time timestamp with time zone NOT NULL DEFAULT ((CURRENT_TIMESTAMP AT TIME ZONE 'UTC'::text)),
        modified_time timestamp with time zone NOT NULL,
        deleted_time timestamp with time zone NOT NULL,
        is_persistent boolean NOT NULL,
        active boolean NOT NULL DEFAULT (true),
        CONSTRAINT "PK_ApplicationUserLogin" PRIMARY KEY (id),
        CONSTRAINT applicationuserlogin_fk FOREIGN KEY (user_id) REFERENCES "ApplicationUser" (id)
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230601223352_Migration01') THEN
    CREATE TABLE "ApplicationUserRole" (
        id uuid NOT NULL,
        user_id uuid NOT NULL,
        role_id uuid NOT NULL,
        created_time timestamp with time zone NOT NULL DEFAULT ((CURRENT_TIMESTAMP AT TIME ZONE 'UTC'::text)),
        modified_time timestamp with time zone NOT NULL,
        deleted_time timestamp with time zone NOT NULL,
        is_persistent boolean NOT NULL,
        active boolean NOT NULL DEFAULT (true),
        CONSTRAINT "PK_ApplicationUserRole" PRIMARY KEY (id),
        CONSTRAINT applicationuserrole_fk FOREIGN KEY (user_id) REFERENCES "ApplicationUser" (id),
        CONSTRAINT applicationuserrole_fk_1 FOREIGN KEY (role_id) REFERENCES "ApplicationRole" (id)
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230601223352_Migration01') THEN
    CREATE TABLE "Cooperative" (
        id uuid NOT NULL,
        cooperative_category_id uuid NULL,
        name text NOT NULL,
        location text NULL,
        phone text NULL,
        url text NULL,
        created_time timestamp with time zone NOT NULL DEFAULT (((CURRENT_TIMESTAMP AT TIME ZONE 'UTC'::text) AT TIME ZONE 'UTC'::text)),
        modified_time timestamp with time zone NOT NULL,
        deleted_time timestamp with time zone NOT NULL,
        "IsPersistent" boolean NOT NULL,
        "Active" boolean NOT NULL,
        CONSTRAINT "PK_Cooperative" PRIMARY KEY (id),
        CONSTRAINT cooperative_fk FOREIGN KEY (cooperative_category_id) REFERENCES "CooperativeCategory" (id)
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230601223352_Migration01') THEN
    CREATE TABLE "GrantSupport" (
        id uuid NOT NULL,
        grant_support_category_id uuid NOT NULL,
        title text NOT NULL,
        description text NULL,
        image uuid NULL,
        created_time timestamp with time zone NOT NULL DEFAULT (((CURRENT_TIMESTAMP AT TIME ZONE 'UTC'::text) AT TIME ZONE 'UTC'::text)),
        modified_time timestamp with time zone NOT NULL,
        deleted_time timestamp with time zone NOT NULL,
        "IsPersistent" boolean NOT NULL,
        "Active" boolean NOT NULL,
        CONSTRAINT "PK_GrantSupport" PRIMARY KEY (id),
        CONSTRAINT grantsupport_fk FOREIGN KEY (grant_support_category_id) REFERENCES "GrantSupportCategory" (id),
        CONSTRAINT grantsupport_fk_1 FOREIGN KEY (image) REFERENCES "File" ("Id")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230601223352_Migration01') THEN
    CREATE TABLE "NewsAnnouncement" (
        id uuid NOT NULL DEFAULT (gen_random_uuid()),
        news_announcement_category_id uuid NULL,
        title text NOT NULL,
        description text NULL,
        image uuid NULL,
        created_time timestamp with time zone NOT NULL DEFAULT (((CURRENT_TIMESTAMP AT TIME ZONE 'UTC'::text) AT TIME ZONE 'UTC'::text)),
        modified_time timestamp with time zone NOT NULL,
        deleted_time timestamp with time zone NOT NULL,
        "IsPersistent" boolean NOT NULL,
        "Active" boolean NOT NULL,
        CONSTRAINT "PK_NewsAnnouncement" PRIMARY KEY (id),
        CONSTRAINT "newsAnnouncement_fk" FOREIGN KEY (news_announcement_category_id) REFERENCES "NewsAnnouncementCategory" (id),
        CONSTRAINT "newsAnnouncement_fk_1" FOREIGN KEY (image) REFERENCES "File" ("Id")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230601223352_Migration01') THEN
    CREATE TABLE "ProductGrowingSuggestion" (
        id uuid NOT NULL,
        product_growing_suggestion_category_id uuid NULL,
        title text NOT NULL,
        description text NULL,
        image text NULL,
        created_time timestamp with time zone NOT NULL DEFAULT (((CURRENT_TIMESTAMP AT TIME ZONE 'UTC'::text) AT TIME ZONE 'UTC'::text)),
        modified_time timestamp with time zone NOT NULL,
        deleted_time timestamp with time zone NOT NULL,
        "IsPersistent" boolean NOT NULL,
        "Active" boolean NOT NULL,
        CONSTRAINT "PK_ProductGrowingSuggestion" PRIMARY KEY (id),
        CONSTRAINT productgrowingsuggestion_fk FOREIGN KEY (product_growing_suggestion_category_id) REFERENCES "ProductGrowingSuggestionCategory" (id)
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230601223352_Migration01') THEN
    CREATE TABLE "ApplicationEndpointApplicationRole" (
        "EndpointsId" uuid NOT NULL,
        "RolesId" uuid NOT NULL,
        CONSTRAINT "PK_ApplicationEndpointApplicationRole" PRIMARY KEY ("EndpointsId", "RolesId"),
        CONSTRAINT "FK_ApplicationEndpointApplicationRole_ApplicationEndpoint_Endp~" FOREIGN KEY ("EndpointsId") REFERENCES "ApplicationEndpoint" ("Id") ON DELETE CASCADE,
        CONSTRAINT "FK_ApplicationEndpointApplicationRole_ApplicationRole_RolesId" FOREIGN KEY ("RolesId") REFERENCES "ApplicationRole" (id) ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230601223352_Migration01') THEN
    INSERT INTO "ApplicationRole" (id, active, created_time, deleted_time, is_persistent, modified_time, name)
    VALUES ('00000000-0000-0000-0000-000000000001', TRUE, TIMESTAMPTZ '2023-06-01 22:33:52.134Z', TIMESTAMPTZ '-infinity', TRUE, TIMESTAMPTZ '-infinity', 'SuperUser');
    INSERT INTO "ApplicationRole" (id, active, created_time, deleted_time, is_persistent, modified_time, name)
    VALUES ('00000000-0000-0000-0000-000000000002', TRUE, TIMESTAMPTZ '2023-06-01 22:33:52.134002Z', TIMESTAMPTZ '-infinity', TRUE, TIMESTAMPTZ '-infinity', 'Admin');
    INSERT INTO "ApplicationRole" (id, active, created_time, deleted_time, is_persistent, modified_time, name)
    VALUES ('00000000-0000-0000-0000-000000000003', TRUE, TIMESTAMPTZ '2023-06-01 22:33:52.134003Z', TIMESTAMPTZ '-infinity', TRUE, TIMESTAMPTZ '-infinity', 'Member');
    INSERT INTO "ApplicationRole" (id, active, created_time, deleted_time, is_persistent, modified_time, name)
    VALUES ('00000000-0000-0000-0000-000000000004', TRUE, TIMESTAMPTZ '2023-06-01 22:33:52.134004Z', TIMESTAMPTZ '-infinity', TRUE, TIMESTAMPTZ '-infinity', 'NewsAnnouncementModule');
    INSERT INTO "ApplicationRole" (id, active, created_time, deleted_time, is_persistent, modified_time, name)
    VALUES ('00000000-0000-0000-0000-000000000005', TRUE, TIMESTAMPTZ '2023-06-01 22:33:52.134005Z', TIMESTAMPTZ '-infinity', TRUE, TIMESTAMPTZ '-infinity', 'GrantSupportModule');
    INSERT INTO "ApplicationRole" (id, active, created_time, deleted_time, is_persistent, modified_time, name)
    VALUES ('00000000-0000-0000-0000-000000000006', TRUE, TIMESTAMPTZ '2023-06-01 22:33:52.134006Z', TIMESTAMPTZ '-infinity', TRUE, TIMESTAMPTZ '-infinity', 'GrowingSuggestionModule');
    INSERT INTO "ApplicationRole" (id, active, created_time, deleted_time, is_persistent, modified_time, name)
    VALUES ('00000000-0000-0000-0000-000000000007', TRUE, TIMESTAMPTZ '2023-06-01 22:33:52.134008Z', TIMESTAMPTZ '-infinity', TRUE, TIMESTAMPTZ '-infinity', 'CooperativesModule');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230601223352_Migration01') THEN
    INSERT INTO "ApplicationUser" (id, access_failed_count, active, created_time, deleted_time, description, email, email_approved, is_persistent, lockout_enabled, lockout_end_date_utc, modified_time, name, normalized_name, password, phone_number, phone_number_approved, "RefreshToken", refresh_token_end_date, security_stamp_date, two_factor_enabled, user_name)
    VALUES ('00000000-0000-0000-0000-000000000001', 0, TRUE, TIMESTAMPTZ '2023-06-01 22:33:52.134487Z', TIMESTAMPTZ '-infinity', NULL, 'burakhansamli0.0.0.0@gmail.com', TRUE, TRUE, FALSE, TIMESTAMPTZ '-infinity', TIMESTAMPTZ '-infinity', 'root', 'ROOT', 'f3f5e898ed41cd8e0b3785bc5bba537deffe3889e525b30e72f947a27c2d2caf986f73663a308e97ba6f24323ce2929e6afe4b86204d93617c16000dd574a8e5', NULL, TRUE, NULL, NULL, TIMESTAMPTZ '2023-06-01 22:33:52.134485Z', TRUE, 'root');
    INSERT INTO "ApplicationUser" (id, access_failed_count, active, created_time, deleted_time, description, email, email_approved, is_persistent, lockout_enabled, lockout_end_date_utc, modified_time, name, normalized_name, password, phone_number, phone_number_approved, "RefreshToken", refresh_token_end_date, security_stamp_date, two_factor_enabled, user_name)
    VALUES ('00000000-0000-0000-0000-000000000002', 0, TRUE, TIMESTAMPTZ '2023-06-01 22:33:52.134491Z', TIMESTAMPTZ '-infinity', NULL, NULL, TRUE, TRUE, FALSE, TIMESTAMPTZ '-infinity', TIMESTAMPTZ '-infinity', 'admin', 'ADMIN', '99ec526fe3e3f956acb4712b6bca88d918a3eb6d3e0a17634667e2775aad07ec1f8f84f8bbbf227eb5e0574177b13c8c30cc71b2d8e9bda722c023a81b754601', NULL, TRUE, NULL, NULL, TIMESTAMPTZ '2023-06-01 22:33:52.13449Z', TRUE, 'admin');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230601223352_Migration01') THEN
    INSERT INTO "ApplicationUserClaim" (id, active, claim_type, claim_value, created_time, deleted_time, is_persistent, modified_time, user_id)
    VALUES ('84de6a5a-8dec-4ded-a8db-26251208d1d5', TRUE, 'ProfilePhoto', 'asset/image/user.png', TIMESTAMPTZ '2023-06-01 22:33:52.134203Z', TIMESTAMPTZ '-infinity', TRUE, TIMESTAMPTZ '-infinity', '00000000-0000-0000-0000-000000000001');
    INSERT INTO "ApplicationUserClaim" (id, active, claim_type, claim_value, created_time, deleted_time, is_persistent, modified_time, user_id)
    VALUES ('d753385c-fbe3-4fca-aa75-ac3ef3ff4e49', TRUE, 'ProfilePhoto', 'asset/image/user.png', TIMESTAMPTZ '2023-06-01 22:33:52.134206Z', TIMESTAMPTZ '-infinity', TRUE, TIMESTAMPTZ '-infinity', '00000000-0000-0000-0000-000000000002');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230601223352_Migration01') THEN
    INSERT INTO "ApplicationUserRole" (id, active, created_time, deleted_time, is_persistent, modified_time, role_id, user_id)
    VALUES ('18b372b4-2a3e-4ded-a00b-b7ae2f6f13db', TRUE, TIMESTAMPTZ '2023-06-01 22:33:52.135014Z', TIMESTAMPTZ '-infinity', TRUE, TIMESTAMPTZ '-infinity', '00000000-0000-0000-0000-000000000002', '00000000-0000-0000-0000-000000000002');
    INSERT INTO "ApplicationUserRole" (id, active, created_time, deleted_time, is_persistent, modified_time, role_id, user_id)
    VALUES ('d9bb29bb-2875-472e-9675-1259dcf78211', TRUE, TIMESTAMPTZ '2023-06-01 22:33:52.13501Z', TIMESTAMPTZ '-infinity', TRUE, TIMESTAMPTZ '-infinity', '00000000-0000-0000-0000-000000000001', '00000000-0000-0000-0000-000000000001');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230601223352_Migration01') THEN
    CREATE INDEX "IX_ApplicationEndpoint_MenuId" ON "ApplicationEndpoint" ("MenuId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230601223352_Migration01') THEN
    CREATE INDEX "IX_ApplicationEndpointApplicationRole_RolesId" ON "ApplicationEndpointApplicationRole" ("RolesId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230601223352_Migration01') THEN
    CREATE INDEX "IX_ApplicationUserClaim_user_id" ON "ApplicationUserClaim" (user_id);
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230601223352_Migration01') THEN
    CREATE INDEX "IX_ApplicationUserLogin_user_id" ON "ApplicationUserLogin" (user_id);
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230601223352_Migration01') THEN
    CREATE INDEX "IX_ApplicationUserRole_role_id" ON "ApplicationUserRole" (role_id);
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230601223352_Migration01') THEN
    CREATE INDEX "IX_ApplicationUserRole_user_id" ON "ApplicationUserRole" (user_id);
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230601223352_Migration01') THEN
    CREATE INDEX "IX_Cooperative_cooperative_category_id" ON "Cooperative" (cooperative_category_id);
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230601223352_Migration01') THEN
    CREATE INDEX "IX_GrantSupport_grant_support_category_id" ON "GrantSupport" (grant_support_category_id);
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230601223352_Migration01') THEN
    CREATE INDEX "IX_GrantSupport_image" ON "GrantSupport" (image);
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230601223352_Migration01') THEN
    CREATE INDEX "IX_NewsAnnouncement_image" ON "NewsAnnouncement" (image);
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230601223352_Migration01') THEN
    CREATE INDEX "IX_NewsAnnouncement_news_announcement_category_id" ON "NewsAnnouncement" (news_announcement_category_id);
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230601223352_Migration01') THEN
    CREATE INDEX "IX_ProductGrowingSuggestion_product_growing_suggestion_categor~" ON "ProductGrowingSuggestion" (product_growing_suggestion_category_id);
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230601223352_Migration01') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20230601223352_Migration01', '6.0.14');
    END IF;
END $EF$;
COMMIT;

