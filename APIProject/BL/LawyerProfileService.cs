using APIProject.Models;
using APIProject.Request;
using APIProject.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIProject.BL
{
    public class LawyerProfileService
    {
        private readonly LawyerAPIDBContext _context;
        public LawyerProfileService(LawyerAPIDBContext context)
        {
            _context = context;
        }
        public ResponseClass Add(LawyerProfileRequest userRequest)
        {
            var res = new ResponseClass();
            try
            {
                var users = _context.Users.Where(a => a.Id == userRequest.UserId).FirstOrDefault();
                if (users == null)
                {
                    res.data = "User not found with the Id";
                    return res;
                }
                var alreadyExists = _context.LawyerProfile.Where(a => a.Users.Id == userRequest.UserId).FirstOrDefault();
                if (alreadyExists != null)
                {
                    res.data = "User not found with the Id";
                    return res;
                }
                var lawprofile = new LawyerProfile()
                {

                    Address = userRequest.Address,
                    Mobile = userRequest.Mobile,
                    Name = userRequest.Name,
                    IsActive = true,
                    CreatedDate = new DateTime(),
                    UpdatedDate = new DateTime(),
                    Users = users,
                    Bio = userRequest.Bio,
                    BioCharLimit = userRequest.BioCharLimit,
                    WorkingArea = userRequest.WorkingArea,
                    Education = userRequest.Education,
                    Experience = userRequest.Experience,
                    PackageSettings = userRequest.PackageSettings,
                    ProfilePic = userRequest.ProfilePic
                };
                _context.LawyerProfile.Add(lawprofile);
                _context.SaveChangesAsync();
                var lastLawer = _context.LawyerProfile.Where(a=>a.Mobile==userRequest.Mobile).FirstOrDefault();
                res.status = true;
                res.data = lastLawer.Id;
                return res;
            }
            catch (Exception ex)
            {
                res.status = false;
                res.data = ex.Message;
                return res;
            }
        }
    }
}
