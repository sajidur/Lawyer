using APIProject.Models;
using APIProject.Request;
using APIProject.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIProject.BL
{
    public class ClientProfileService
    {
        private readonly LawyerAPIDBContext _context;
        public ClientProfileService(LawyerAPIDBContext context)
        {
            _context = context;
        }
        public ResponseClass Add(ClientProfileRequest request)
        {
            var res = new ResponseClass();
            try
            {
                var users = _context.Users.Where(a => a.Id == request.UserId).FirstOrDefault();
                if (users == null)
                {
                    res.data = "User not found with the Id";
                    return res;
                }
                var alreadyExists = _context.ClientProfile.Where(a => a.Users.Id == request.UserId).FirstOrDefault();
                if (alreadyExists != null)
                {
                    res.data = "User not found with the Id";
                    return res;
                }
                var clientProfile = new ClientProfile()
                {

                    Address = request.Address,
                    Mobile = request.Mobile,
                    Name = request.Name,
                    IsActive = true,
                    CreatedDate = new DateTime(),
                    UpdatedDate = new DateTime(),
                    Users = users
                };
                _context.ClientProfile.Add(clientProfile);
                _context.SaveChanges();
                res.status = true;
                res.data = request.Mobile;
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
