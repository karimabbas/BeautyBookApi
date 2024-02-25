using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyBook.Models
{
    public enum AppointmentStatus
    {
        done,
        canceled,
        needsEmployeeConfirmation,
        needsCustomerConfirmation,
    }
}