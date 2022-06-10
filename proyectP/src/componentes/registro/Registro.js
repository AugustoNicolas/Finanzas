import React from "react";
import { Link } from "react-router-dom";

class Registro extends React.Component{
    render(){
        return(
            <div class="bd">
                <div class="container w-75 bg-primary mt-4 rounded shadow">
                    <div class="row">
                        <div class="col bg d-none d-lg-block col-md-5 col-lg-5 col-xl-6 rounded" >

                        </div>
                    <div class="col bg-white p-4 rounded-end">
                    <div class="text-center">
                        <img src="" alt="" width="" height="" />
                        <p>LOGO</p>
                    </div>
                    <h2 class="fw-bold text-center">Registro</h2>

                    <form action="#">
                    <div class="mb-2">
                            <label for="name" class="form-label">Nombre</label>
                            <input type="text" class="form-control" name="name"/>
                        </div>
                        <div class="mb-4">
                            <label for="email" class="form-label">Correo electronico</label>
                            <input type="email" class="form-control" name="email"/>
                        </div>
                        <div class="mb-4">
                            <label for="cpassword" class="form-label">Contraseña</label>
                            <input type="cpassword" class="form-control" name="cpassword"/>
                        </div>
                        <div class="mb-4">
                            <label for="password" class="form-label">Confirmar Contraseña</label>
                            <input type="password" class="form-control" name="password"/>
                        </div>
                        <div class="mb-4 form-check">
                            <input type="checkbox" class="form-check-input" name="connectec"/>
                            <label for="connected" class="form-check-label">Acepto todas las declaraciones en <a href="#">Terminos de servicio</a> </label>
                        </div>
                        <div class="text-center">
                            <Link to="/" ><button type="submit" class="btn btn-primary w-100">Registrarse</button></Link>
                        </div>
                        
                    </form>

                    
                    </div>
                </div>    
                </div>  
      </div>
        )
    }
}

export default Registro