import React from "react";
import { Link } from "react-router-dom";
import './Login.css'

class Login extends React.Component{
  constructor(props){
    super(props)
    this.state = {
      backgroundColor: props.bgColor,
    }
  }
  render(){
    return (
      <div class="bd">
        <div class="container w-75 bg-primary mt-4 rounded shadow">
          <div class="row">
            <div class="col bg d-none d-lg-block col-md-5 col-lg-5 col-xl-6 rounded" >

            </div>
            <div class="col bg-white p-3 rounded-end">
              <div class="text-center">
                <img src="" alt="" width="" height="" />
                <p>LOGO</p>
              </div>
              <h2 class="fw-bold text-center py-5">Iniciar Sesion</h2>

              <form action="#">
                <div class="mb-4">
                  <label for="email" class="form-label">Correo electronico</label>
                  <input type="email" class="form-control" name="email"/>
                </div>
                <div class="mb-4">
                  <label for="password" class="form-label">Password</label>
                  <input type="password" class="form-control" name="email"/>
                </div>
                <div class="mb-4 form-check">
                  <input type="checkbox" class="form-check-input" name="connectec"/>
                  <label for="connected" class="form-check-label">Mantener session iniciada</label>
                </div>
                <div class="text-center">
                  <Link to="/inicio" ><button type="submit" class="btn btn-primary w-100">Iniciar sesion</button></Link>
                </div>
                <div class="my-3">
                  <span>No tienes cuenta? <Link to="/registro">Registrate</Link></span><br/>
                </div>
              </form>

            
            </div>
          </div>    
        </div>  
      </div>
    );
  }
}

export default Login