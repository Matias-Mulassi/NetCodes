//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoWEB2 {
    using System;
    
    
    /// <summary>
    ///   Clase de recurso fuertemente tipado, para buscar cadenas traducidas, etc.
    /// </summary>
    // StronglyTypedResourceBuilder generó automáticamente esta clase
    // a través de una herramienta como ResGen o Visual Studio.
    // Para agregar o quitar un miembro, edite el archivo .ResX y, a continuación, vuelva a ejecutar ResGen
    // con la opción /str o recompile su proyecto de VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class RecursosSQL {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal RecursosSQL() {
        }
        
        /// <summary>
        ///   Devuelve la instancia de ResourceManager almacenada en caché utilizada por esta clase.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("ProyectoWEB2.RecursosSQL", typeof(RecursosSQL).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Reemplaza la propiedad CurrentUICulture del subproceso actual para todas las
        ///   búsquedas de recursos mediante esta clase de recurso fuertemente tipado.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a DROP PROCEDURE [dbo].[sp_Borra_Personas_Menores];.
        /// </summary>
        internal static string Borra_sp_Borrar_Personas_Menores {
            get {
                return ResourceManager.GetString("Borra_sp_Borrar_Personas_Menores", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a CREATE PROCEDURE [dbo].[sp_Borra_Personas_Menores]
        ///
        ///AS
        ///BEGIN
        ///
        ///	SET NOCOUNT ON;
        ///
        ///	DELETE Personas
        ///	where Edad &lt;18;
        ///END.
        /// </summary>
        internal static string Crear_sp_Borra_Personas_Menores {
            get {
                return ResourceManager.GetString("Crear_sp_Borra_Personas_Menores", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a [dbo].[sp_Borra_Personas_Menores].
        /// </summary>
        internal static string sp_Borra_Personas_Menores_Nombre {
            get {
                return ResourceManager.GetString("sp_Borra_Personas_Menores_Nombre", resourceCulture);
            }
        }
    }
}
