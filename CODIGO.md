# Estandarización de código:

La siguiente información es la estabilización de código que se usara dentro del proyecto. Es importante seguir las siguientes convenciones para mantener la unificación del código.

* Usar tabulación de 2 espacios.
* Abrir corchetes al inicio de línea.
* Agregar parametros se separa por una coma y se deja un espacio al siguiente parametro.
* Nombra con la primera letra minúscula y en caso de necesitarse más palabras se sigue con la siguiente palabra en Mayúscula y sin espacios.

## Crear comentarios

* Se deben crear siempre antes de cualquier bloque de código creado.
* Se hace con comentario simple y se debe poner un espacio después `// Inicio de texto` de esta manera.
* Después de finalizar la descripción poner un punto.

##### *Plantilla*:
```csharp
// Estado: [Estados - Activo, Inactivo, Cambiado]
// Creado por [Nombre] - [Fecha - Formato "dd.mm.yyyy"]
// [Descripcion corta].
```
##### *Ejemplo*:
```csharp
// Estado: Activo
// Creado por Miguel Bogota - 09.11.2019
// Este comentario sirve como un ejemplo a como se debe hacer.
```

## Crear clases

* Tener bloque de comentario antes de crear la clase.
* Dejar un espacio en blanco después de corchetes.
* Nombre de la clase debe ser con la primera letra en mayúscula e intuitivo.
* Se sigue la misma estructura de nombramiento en caso de necesitar más de una palabra.

##### *Plantilla*:
```csharp
// Estado: [Estados - Activo, Inactivo, Cambiado]
// Creado por [Nombre] - [Fecha - Formato "dd.mm.yyyy"]
// [Descripcion corta].
public class NombreClase {

  // Constructor
  public NombreClase(string nombrePropiedad, int nombreVariable2) {
    // Código
  }

}
```

## Crear funciones

* Tener bloque de comentario antes de crear la clase.
* Después del nombre de la función los paréntesis no deben tener ningún espacio a los corchetes.
* Dejar un espacio en blanco después de corchetes.

##### *Plantilla*:
```csharp
// Estado: [Estados - Activo, Inactivo, Cambiado]
// Creado por [Nombre] - [Fecha - Formato "dd.mm.yyyy"]
// [Descripcion corta].
public void nombreFuncion(string nombreVariable, int nombreVariable2) {
  // Código
}
```

## Crear Variables/Propiedades

* Siempre crear las Variables/Propiedades al inicio de la clase debajo del comentario de creación de Variables/Propiedades.
* En este caso no es necesario tener un bloque de comentario antes con la información.
* Después de cerrar la linea de código poner un espacio y abrir línea de código dejar otro espacio e indicar una descripción corta.
* Después del nombre de la función los paréntesis no deben tener ningún espacio a los corchetes.
* Dejar un espacio en blanco después de corchetes.
* Se deben iniciar en el constructor y se usa el mismo comentario describiendo la acción de iniciar.
* Se siguen las normas de encapsulamiento y se generan al final de la clase las funciones de Get y Set.

##### *Plantilla*:
```csharp
// Estado: [Estados - Activo, Inactivo, Cambiado]
// Creado por [Nombre] - [Fecha - Formato "dd.mm.yyyy"]
// [Descripcion corta].
public class NombreClase {

  // ****** Creación de Variables/Propiedades ****** //
  private string nombreVariable; // Descripción muy corta
  private int nombreVariable2; // Descripción muy corta

  // Constructor
  public NombreClase() {
    this.nombreVariable = ""; // Valor inicial
    this.nombreVariable2 = 0; // Valor inicial
  }

  // Estado: [Estados - Activo, Inactivo, Cambiado]
  // Creado por [Nombre] - [Fecha - Formato "dd.mm.yyyy"]
  // [Descripcion corta].
  public void nombreFuncion(string nombreVariable, int nombreVariable2) {
    this.nombreVariable = nombreVariable; // Descripción corta de acción
    this.nombreVariable2 = nombreVariable2; // Descripción corta de acción
  }

  // ****** Getters y Setters ****** //

  public string getNombreVariable() {
    return this.getVariable;
  }

  public string setNombreVariable(string valor) {
    this.getVariable = valor;
  }

  public string getNombreVariable2() {
    return this.getVariable2;
  }

  public string setNombreVariable2(string valor) {
    this.getVariable2 = valor;
  }

}
```

## Cambiar código

* Nunca borrar código generado por otra persona, en vez comentarlo.
* Comentar con bloque de código y después de cerrar usar plantilla de comentario y cambiar el estado anterior ya sea a Inactivo o Cambiado.

##### *Plantilla*:
```csharp
// Estado: [Estados - Inactivo, Cambiado]
// Creado por [Nombre] - [Fecha - Formato "dd.mm.yyyy"]
// [Descripcion corta].
/*
public void nombreFuncion(string nombreVariable, int nombreVariable2) {
  this.nombreVariable = nombreVariable; // Descripción corta de acción
  this.nombreVariable2 = nombreVariable2; // Descripción corta de acción
}
*/
// Estado: [Estados - Activo, Inactivo, Cambiado]
// Creado por [Nombre] - [Fecha - Formato "dd.mm.yyyy"]
// [Descripcion corta].
public void nombreFuncionNueva(string nombreVariable, int nombreVariable2) {
  this.nombreVariable2 = nombreVariable2; // Descripción corta de acción
  this.nombreVariable = nombreVariable; // Descripción corta de acción
}

```