import React from "react";
import { Link } from "react-router-dom";

class Registro extends React.Component{
    render(){
        return(
            <div className="bd">
                <div className="container w-75 bg-primary mt-4 rounded shadow">
                    <div className="row">
                        <div className="col bg d-none d-lg-block col-md-5 col-lg-5 col-xl-6 rounded" >

                        </div>
                    <div className="col bg-white p-4 rounded-end">
                    <div className="text-center">
                        <img src="" alt="" width="" height="" />
                        <p>LOGO</p>
                    </div>
                    <h2 className="fw-bold text-center">Registro</h2>

                    <form action="#">
                    <div className="mb-2">
                            <label for="name" className="form-label">Nombre</label>
                            <input type="text" className="form-control" name="name"/>
                        </div>
                        <div className="mb-4">
                            <label for="email" className="form-label">Correo electronico</label>
                            <input type="email" className="form-control" name="email"/>
                        </div>
                        <div className="mb-4">
                            <label for="cpassword" className="form-label">Contraseña</label>
                            <input type="cpassword" className="form-control" name="cpassword"/>
                        </div>
                        <div className="mb-4">
                            <label for="password" className="form-label">Confirmar Contraseña</label>
                            <input type="password" className="form-control" name="password"/>
                        </div>
                        <div className="mb-4 form-check">
                            <input type="checkbox" className="form-check-input" name="connectec"/>
                            <label for="connected" className="form-check-label">Acepto todas las declaraciones en <a href="#">Terminos de servicio</a> </label>
                        </div>
                        <div className="text-center">
                            <Link to="/login" ><button type="submit" className="btn btn-primary w-100">Registrarse</button></Link>
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