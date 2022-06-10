import React from 'react';
 
import Menu from '../menu/Menu';
import Jumbotron from './jumbotron/Jumbotron'; 
import Detalles from './detalles/Detalles'; 
import Footer from '../footer/Footer';
import Advice from '././../nosotros/advice/Advice.js';
 
class Nosotros extends React.Component {
 
    render() {
    
    return(
    
    <>
    
        <Menu />
    
        <main role="main" className="containe-fluid">
            
            <Jumbotron /> 
            <Advice/>
            <br />
            <Detalles /> 
    
        </main>
    
        <Footer />
    
        </>
    
    )
    
    }
 
}
 
export default Nosotros;