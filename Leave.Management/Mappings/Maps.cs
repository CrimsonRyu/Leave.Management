using AutoMapper;
using Leave.Management.Data;
using Leave.Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leave.Management.Mappings
{
    public class Maps : Profile
    {
        public Maps() 
        {
            CreateMap<LeaveType, LeaveTypeModel>().ReverseMap();
            CreateMap<LeaveAllocation, LeaveAllocationModel>().ReverseMap();
            CreateMap<LeaveHistory, LeaveHistoryModel>().ReverseMap();
            CreateMap<Employee, EmployeeModel>().ReverseMap();
        }
    }
}
