import React from 'react';
import '../../../App.css';
const styles={
  bd:{
     background: '#ffe259',
     background: 'linear-gradient(to right, #893DFD, #00A2FF, #00CEFF)'
  },
  
}

class Formulario extends React.Component {

  render() {

    return (
        <div className="container w-75 rounded shadow" style={styles.bd}>
          <h1 className="mb-4 text-center text-light">Contacto</h1>
          <form className="mb-5">

            <div className="form-group">
              <label htmlFor="nya" className="negrita text-light">Nombres y Apellidos</label>
              <input type="text" className="form-control" id="nya" required />            
            </div>

            <div className="form-group">
              <label htmlFor="email" className="negrita text-light">Email</label>
              <input type="email" className="form-control" id="email" required />
            </div>

            <div className="form-group">
              <label htmlFor="asunto" className="negrita text-light">Asunto</label>
              <input type="text" className="form-control" id="asunto" required />
            </div>

            <div className="form-group">
              <label htmlFor="mensaje" className="negrita text-light">Mensaje</label>
              <textarea className="form-control" id="mensaje" required></textarea>
            </div>

            <button type="submit" className="w-100 btn btn-light mt-3 mb-3" id='btnCont' style={styles.btn}>Enviar</button>

          </form>
        </div>

    )
    
  }

}

export default Formulario;