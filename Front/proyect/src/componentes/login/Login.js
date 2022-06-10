import React from "react";
import { Link } from "react-router-dom";
import './Login.css'
import axios from "axios";

const baseUrl="https://localhost:7265/api/Usuarios";

class Login extends React.Component{
  state={
    form:{
      correo: '',
      clave: ''
    }
  }
  handleChange=async e=>{
    await this.setState({
      form:{
        ...this.state.form,
        [e.target.name]: e.target.value
      }
    });
    console.log(this.state.form);
  }
  iniciarSesion=async()=>{
    await axios.get(baseUrl, {params: {correo: this.state.form.correo, clave: this.state.form.clave}})
    .then(response=>{
      console.log(response.data)
    })
    .catch(error=>{
      console.log(error);
    })
  }
  render(){
    return (
      <div className="bd">
        <div className="container w-75 bg-primary mt-4 rounded shadow">
          <div className="row">
            <div className="col bg d-none d-lg-block col-md-5 col-lg-5 col-xl-6 rounded" >

            </div>
            <div className="col bg-white p-3 rounded-end">
              <div className="text-center">
                <img src="" alt="" width="" height="" />
                <p>LOGO</p>
              </div>
              <h2 className="fw-bold text-center py-5">Iniciar Sesion</h2>

              <form action="#">
                <div className="mb-4">
                  <label for="username" className="form-label">Nombre de usuario</label>
                  <input type="username" className="form-control" name="username" onChange={this.handleChange}/>
                </div>
                <div className="mb-4">
                  <label for="email" className="form-label">Correo electronico</label>
                  <input type="email" className="form-control" name="correo" onChange={this.handleChange}/>
                </div>
                <div className="mb-4">
                  <label for="password" className="form-label">Password</label>
                  <input type="password" className="form-control" name="clave" onChange={this.handleChange}/>
                </div>
                <div className="mb-4 form-check">
                  <input type="checkbox" className="form-check-input" name="connectec"/>
                  <label for="connected" className="form-check-label">Mantener session iniciada</label>
                </div>
                <div className="text-center">
                  <button type="button" className="btn btn-primary w-100" onClick={()=> this.iniciarSesion()}>Iniciar sesion</button>
                </div>
                <div className="my-3">
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