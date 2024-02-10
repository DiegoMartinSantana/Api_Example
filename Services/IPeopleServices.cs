using Microsoft.AspNetCore.Mvc;

namespace Api.Services
{
    public interface IPeopleServices
    {
        //no le paso public porque es una interfaz
        //solo especifico que va a existir un metodo! no que hace
        bool  Validate(People people);

    }
}
