using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.BusinessAspects;

[AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
public class SecuredOperationAttribute : Attribute
{
    public string Roles { get; }

    public SecuredOperationAttribute(string roles)
    {
        Roles = roles;
    }
} 

