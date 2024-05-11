using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstacionamientoMedido.Modelos;
using FluentValidation;

namespace EstacionamientoMedido.Validaciones
{
    public class VehiculoValidator : AbstractValidator<Vehiculo>
    {
        public VehiculoValidator()
        {
            // TAREA: Implementar todas las validaciones para vehiculo, cliente y plaza estacionamiento
            RuleFor(x => x.Marca)
                .NotNull()
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(20);

            RuleFor(x=> x.Modelo)
                .NotNull()
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(20);
        }
    }
}
