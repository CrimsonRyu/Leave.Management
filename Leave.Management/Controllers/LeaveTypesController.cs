using AutoMapper;
using Leave.Management.Contracts;
using Leave.Management.Data;
using Leave.Management.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leave.Management.Controllers
{
    public class LeaveTypesController : Controller
    {
        private readonly ILeaveTypeRepository _leaveTypeRepo;
        private readonly IMapper _mapper;

        public LeaveTypesController(ILeaveTypeRepository repo, IMapper mapper)
        {
            _leaveTypeRepo = repo;
            _mapper = mapper;
        }

        // GET: LeaveTypesController
        public ActionResult Index()
        {
            var leaveTypes = _leaveTypeRepo.FindAll().ToList();

            //Map to View model
            var model = _mapper.Map<List<LeaveType>, List<LeaveTypeModel>>(leaveTypes);
            return View(model);
        }

        // GET: LeaveTypesController/Details/5
        public ActionResult Details(int id)
        {
            if (!_leaveTypeRepo.isExists(id))
            {
                return NotFound();
            }

            var leaveType = _leaveTypeRepo.FindById(id);
            var model = _mapper.Map<LeaveTypeModel>(leaveType);

            return View(model);
        }

        // GET: LeaveTypesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeaveTypesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LeaveTypeModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var leaveType = _mapper.Map<LeaveType>(model);
                leaveType.DateCreated = DateTime.UtcNow;

                var isSuccess = _leaveTypeRepo.Create(leaveType);

                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Something went Wrong!!!");
                    return View(model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Something went Wrong!!!");
                return View(model);
            }
        }

        // GET: LeaveTypesController/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_leaveTypeRepo.isExists(id))
            {
                return NotFound();
            }

            var leaveType = _leaveTypeRepo.FindById(id);
            var model = _mapper.Map<LeaveTypeModel>(leaveType);

            return View(model);
        }

        // POST: LeaveTypesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, LeaveTypeModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var leaveType = _mapper.Map<LeaveType>(model);

                var isSuccess = _leaveTypeRepo.Update(leaveType);
                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Something went Wrong!!!");
                    return View(model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Something went Wrong!!!");
                return View(model);
            }
        }

        // GET: LeaveTypesController/Delete/5
        public ActionResult Delete(int id)
        {
            var leaveType = _leaveTypeRepo.FindById(id);

            if (leaveType == null)
            {
                return NotFound();
            }

            var isSuccess = _leaveTypeRepo.Delete(leaveType);
            if (!isSuccess)
            {
                ModelState.AddModelError("", "Something went Wrong!!!");
                return BadRequest();
            }

            return RedirectToAction(nameof(Index));

        }
    }
}
