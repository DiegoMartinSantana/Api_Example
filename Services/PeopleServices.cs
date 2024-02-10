namespace Api.Services
{
    // le digo que usa la interfaz, entonces la obligo a tener sus REGLAS
    public class PeopleServices : IPeopleServices
    {
        public bool Validate(People people)
        {
            if (string.IsNullOrEmpty(people.Name))
            {
                return false;
            }
            return true;
        }

    }
}
