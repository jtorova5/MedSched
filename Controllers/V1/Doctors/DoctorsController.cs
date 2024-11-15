using MedSched.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MedSched.Controllers.V1.Doctors;

[ApiController]
[Route("api/v1/doctors")]
public class DoctorsController : ControllerBase
{
    protected readonly IDoctorRepository _doctorRepository;

    public DoctorsController(IDoctorRepository doctorRepository)
    {
        _doctorRepository = doctorRepository;
    }
}

