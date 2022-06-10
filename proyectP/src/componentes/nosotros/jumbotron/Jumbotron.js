import React from 'react';

 class Jumbotron extends React.Component {
  render() {
    
    return (
 
        <div className="jumbotron" >
            <div className="container">
                <h1 className="display-3">Nosotros </h1>
                <p>
                    Somos jovenes algo imprudentes, por lo tanto, las finanzas no son nuestro fuerte. Por eso decidimos facilitar esta tarea
                    a todo aquel que se identifique con nuestra situacion. Las finanzas son un gran problema si no la sabes administrar, por 
                    eso MyMoney no te dejará pasar por eso de nuevo.
                    <br/>
                    Esperamos que este proyecto pueda servir de gran manera, juntos, haremos de este problema nuestro fuerte, ¡esperamos que lo disfrutes!
                </p>
            </div>
        </div> 
    )
    
  }
 
}
 
export default Jumbotron;