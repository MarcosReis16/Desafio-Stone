using System.ComponentModel;

namespace Stone.Dominio.Enums
{
    /// <summary>
    /// Enumerador responsável pelo sexo
    /// </summary>
    public enum ESexo : int
    {
        /// <summary>
        /// Masculino
        /// </summary>
        [Description("Masculino")]
        Masculino = 1,

        /// <summary>
        /// Feminino
        /// </summary>
        [Description("Feminino")]
        Feminino = 2,

        /// <summary>
        /// Não declarado
        /// </summary>
        [Description("Não declarado")]
        NaoDeclarado = 3
    }
}
