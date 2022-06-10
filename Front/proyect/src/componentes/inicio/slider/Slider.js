import React from 'react';
import fondo from '../../img/fondo.JPG';
import {Link} from 'react-router-dom';

//import './Slider.css';
const styles={
    fondito:{
        width:'100%',
        
    },
    contenedor: {
        display:'flex',
        justifyContent: 'center',
        border: 'none',
    },
    parrafo: {
        alignItems:'center',
        display:'flex',
        justifyContent: 'center',
        textAlign:'center',
        color:'white',
    },
    h1:{
        textAlign:'center',
        fontFamily: 'Segoe UI, Tahoma, Geneva, Verdana, sans-serif',
        fontWeight: 'bolder',
        fontSize: '80px',
    },
    pa:{
        fontSize: '30px',
        textAlign:'center',
    },
    textos:{
        display:'flex',
        flexDirection:'column',
        maxWidth:'650px',
    },
    boton:{
        alignItems:'center',
        fontWeight: 'bold',
        width:'300px',
        height:'75px',
        borderRadius:'30px',
        fontSize: '40px',
    }
}
class Slider extends React.Component {
 
  render() {
 
   return (
    <div className="card text-dark" style={styles.contenedor}>
        <img className="card-img" src={fondo} style={styles.fondito} alt="Card image" />
        <div className="card-img-overlay" style={styles.parrafo}>
            <div style={styles.textos}>
                <p className="card-title" style={styles.h1}>Tus finanzas al siguiente nivel</p>
                <p className="card-text" style={styles.pa}>Estamos aqui para ayudarte, tus finanzas no serán un dolor de cabeza de nuevo</p>
                <div>
                    <Link to="/login" ><button type="submit" className="btn btn-primary" style={styles.boton}>¡Comenzar!</button></Link>
                </div>
            </div>
        </div>
    </div>
 
   )
    
  }
 
}
 
export default Slider;