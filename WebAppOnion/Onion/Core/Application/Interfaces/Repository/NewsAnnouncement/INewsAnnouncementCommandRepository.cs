using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Concrete;

namespace Application.Interfaces.Repository.NewsAnnouncement;

public interface INewsAnnouncementCommandRepository : ICommandRepository<Domain.Entities.Concrete.NewsAnnouncement> {


}
