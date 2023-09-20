using System;
using ItesDemo.Models;
using ItesDemo.Configuration;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItesDemo.Services
{
    internal class ApiClient
    {
        static HttpClient httpClient;
       // private Uri URL = new Uri("http://localhost:7085/api");   // aca puse direccion de la API en local
        private Uri URL = new Uri("http://192.168.2.104:7085/api"); // Al tener  la API y la base de datos
                                                                    // de manera local cuando  instalo la  app en un dispositivo ,
                                                                    // tengo que dar permisos en router y el firewall(para probar
                                                                    // puedo desactivarlo tambien).
        

        public ApiClient()
        {
            httpClient = new HttpClient();
        }

        public async Task<LoginResponseModel> ValidarLogin(string _usuario, string _password)
        {
            try
            {
                var loginParams = new StringContent(
                        JsonConvert.SerializeObject(
                            new
                            {
                                usuario = _usuario,
                                password = _password,
                                // password = Encriptar.GetSHA256(_password),

                            }),
                            Encoding.UTF8, "application/json"
                        );

                var result = await httpClient.PostAsync($"{URL}/Usuarios/login", loginParams).ConfigureAwait(false);

                var json = await result.Content.ReadAsStringAsync();

                LoginResponseModel responseLogin;

                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    responseLogin = JsonConvert.DeserializeObject<LoginResponseModel>(json);

                    AppConfiguration.Token = responseLogin.token;

                    return responseLogin;
                }
                else
                {
                    responseLogin = null;
                }
                return responseLogin;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return null;

        }

        /* public async Task<UsuarioModel> ObtenerDatosPersona(string _dni)
        {

            var result = await httpClient.GetAsync($"{URL}/usuarios/ObtenerDatosPersonales/{_dni}").ConfigureAwait(false);

            var json = await result.Content.ReadAsStringAsync();

            UsuarioModel usuarioModel;

            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                usuarioModel = JsonConvert.DeserializeObject<UsuarioModel>(json);

                return usuarioModel;
            }
            else
            {
                usuarioModel = null;
            }

            return usuarioModel;
        } */

        public async Task<IEnumerable<ProductosModel>> ObtenerProductos()
        {
            try
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer"+Configuration.AppConfiguration.Token);
                var json = await httpClient.GetStringAsync($"{URL}/Productos");

                var result = JsonConvert.DeserializeObject<IEnumerable<ProductosModel>>(json);

                return result;

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        /* public async Task<IEnumerable<AlumnosMateriaModel>> ObtenerAlumnosMateria(string carreramateriadiv)
        {
            try
            {
                var json = await httpClient.GetStringAsync($"{URL}/asistencia/ObtenerAlumnosMateria/{carreramateriadiv}");

                var result = JsonConvert.DeserializeObject<IEnumerable<AlumnosMateriaModel>>(json);

                return result;

            }
            catch (Exception ex)
            {
                return null;
            }


        }

        public async Task<bool> ConfirmarAsistenciaMateria(List<AlumnosMateriaModel> listaAsistencia)
        {
            var data = new StringContent(
                        JsonConvert.SerializeObject(listaAsistencia),
                            Encoding.UTF8, "application/json"
                        );

            var result = await httpClient.PostAsync($"{URL}/asistencia", data);

            return result.StatusCode == System.Net.HttpStatusCode.OK;

        } */
    }
}
