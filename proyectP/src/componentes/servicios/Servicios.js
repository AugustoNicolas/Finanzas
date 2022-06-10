import React from 'react';
 
import Menu from '../menu/Menu';
import Footer from '../footer/Footer';
import Fondof from '../img/fondof.jpg';
import Categorias from '../img/categorias.jpg'

class Servicios extends React.Component {
 
  render() {
 
    return(
      <>
        <Menu/>
        <div class="card mb-3">
          <img class="card-img-top" src={Fondof} alt="Card image cap"/>
          <div class="card-body">
            <h1 class="card-title">Tu espacio</h1>
            <p class="card-text">Es aqui donde podrás empezar tu aventura, añadirás saldo, verás tu progreso, recibirás informacion y mucho más... dale click al botón 'Comenzar'
            para dar inicio a tu nueva travesía con las finanzas</p>
            <p><a className="btn btn-primary btn-lg" href='http://localhost:3000/#/servicios' target="_blank"  role="button">Comenzar</a></p>
          </div>
        </div>
        <hr/>
        <div class="card mb-3">
          <img class="card-img-top" src={Categorias} alt="Card image cap"/>
          <div class="card-body">
            <h1 class="card-title">Categorias</h1>
            <p class="card-text">¡Aquí podrás visualizar las distintas categorias disponibles!, tambie podras añadir, restar o actualizarlas a tu estilo</p>
            <p><a className="btn btn-primary btn-lg" href='http://localhost:3000/#/servicios' target="none"  role="button">Ir a categorias</a></p>
          </div>
        </div>
      
        <Footer />
      
      </>
 
    )
 
  }
 
}
 
export default Servicios;