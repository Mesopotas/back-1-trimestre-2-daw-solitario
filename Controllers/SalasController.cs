using Microsoft.AspNetCore.Mvc;

namespace back_1_trimestre_2_daw_solitario.Controllers
{
    [ApiController]
    [Route("MinimalCinema/[controller]")]
    public class SalasController : ControllerBase
    {
        private static List<Salas> salas = new List<Salas>();

        public SalasController()
        {
            if (salas.Count == 0)
            {
                InicializarSalas();
            }
        }


        //FindAll

        [HttpGet]
        public ActionResult<IEnumerable<Salas>> GetAll()
        {
            return Ok(salas);
        }


        //Find All by Id

        [HttpGet("{id}")]
        public ActionResult<Salas> GetById(int id)
        {
            var sala = salas.FirstOrDefault(s => s.Id == id);

            if (sala == null)
                return NotFound();
            return Ok(sala);

        }


        //Find a site by Id


        [HttpGet("{id}/asientos")]
        public ActionResult<IEnumerable<Asientos>> GetAsientos(int id)
        {
            var sala = salas.FirstOrDefault(s => s.Id == id);
            if (sala == null)
                return NotFound();

            return Ok(sala.Asientos);
        }


        //Create a new "Sala", automatic Id

        [HttpPost]
        public ActionResult<Salas> Create([FromBody] Salas nuevaSala)
        {
            nuevaSala.Id = salas.Count > 0 ? salas.Max(s => s.Id) + 1 : 1;

            nuevaSala.Asientos = InicializarAsientos(nuevaSala.Capacidad);
            salas.Add(nuevaSala);
            return CreatedAtAction(nameof(GetById), new { id = nuevaSala.Id }, nuevaSala);
        }


        //Modifi state of a site

        [HttpPut("{id}/asientos/{numero}")]
        public ActionResult ActualizarEstadoAsiento(int id, int numero, [FromBody] bool estaReservado)
        {
            var sala = salas.FirstOrDefault(s => s.Id == id);
            if (sala == null)
                return NotFound("Sala no encontrada");

            var asiento = sala.Asientos.FirstOrDefault(a => a.Numero == numero);
            if (asiento == null)
                return NotFound("Asiento no encontrado");

            asiento.EstaReservado = estaReservado;
            return NoContent();
        }



        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var sala = salas.FirstOrDefault(b => b.Id == id);
            if (sala == null)
            {
                return NotFound($"Opinión con ID {id} no encontrada.");
            }

            salas.Remove(sala);
            return NoContent();
        }



        private static void InicializarSalas()
        {
            salas.Add(new Salas(1, "Sala 1", 100, InicializarAsientos(100)));
            salas.Add(new Salas(2, "Sala 2", 100, InicializarAsientos(100)));
            salas.Add(new Salas(3, "Sala 3", 100, InicializarAsientos(100)));
            salas.Add(new Salas(4, "Sala 4", 100, InicializarAsientos(100)));
            salas.Add(new Salas(5, "Sala 5", 100, InicializarAsientos(100)));
            salas.Add(new Salas(6, "Sala 6", 100, InicializarAsientos(100)));
        }

        private static List<Asientos> InicializarAsientos(int capacidad)
        {
            var asientos = new List<Asientos>();
            for (int i = 1; i <= capacidad; i++)
            {
                asientos.Add(new Asientos(i, false)); // Todos los asientos no están reservados inicialmente
            }
            return asientos;
        }

        public static List<Salas> GetSalas()
        {
            return salas;
        }

    }
    
}