using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OLSoftwareApi.Models.DTO;
using System.Data;

namespace OLSoftwareApi.Models.Repository
{
    public class DetalleRepository : IDetalleRepository
    {
        private readonly IConfiguration _configuration;

        public DetalleRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DetalleDTO GetDetalle(int id)
        {
            DetalleDTO detalle = new DetalleDTO();
            try
            {
                List<Detalle> datos = new List<Detalle>();
                var cnn = _configuration.GetConnectionString("Conexion");
                using (SqlConnection connection = new SqlConnection(cnn))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("ObtenerDetalle", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@id", id); 

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Detalle dto  = new Detalle();
                                dto.UserName = (string)reader["UserName"];
                                dto.NombreAspirante = (string)reader["NombreAspirante"];
                                dto.ApellidoAspirante = (string)reader["ApellidoAspirante"];
                                dto.FechaNacimiento = (string)reader["FechaNacimiento"];
                                dto.Celular = (string)reader["Celular"];
                                dto.Email = (string)reader["Email"];
                                dto.Direccion = (string)reader["Direccion"];
                                dto.Pais = (string)reader["Pais"];
                                dto.Ciudad = (string)reader["Ciudad"];
                                dto.Documento = (string)reader["Documento"];
                                dto.NombrePrueba = (string)reader["NombrePrueba"];
                                dto.CantidadPreguntas = (string)reader["CantidadPreguntas"].ToString();
                                dto.FechaInicio = (string)reader["FechaInicio"];
                                dto.FechaFinalizacion = (string)reader["FechaFinalizacion"];
                                dto.ContenidoPreguntas = (string)reader["ContenidoPreguntas"];
                                datos.Add(dto);
                            }
                        }
                    }
                }                
                var preguntas = new List<string>();                
                detalle.Detalle = datos.FirstOrDefault();
                foreach (var dto in datos)
                {
                    preguntas.Add(dto.ContenidoPreguntas);
                }
                detalle.Preguntas  = preguntas;

                return detalle;
            }
            catch (Exception ex)
            {
                detalle.Detalle.ContenidoPreguntas = ex.Message.ToString();
                return detalle;
            }
        }
    }
}
