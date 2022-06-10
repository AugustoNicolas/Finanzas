import React from 'react';

const styles = {
  mapa: {
      width: '500px',
      height: '300px'
  }
}
class Mapa extends React.Component {

  render() {

    return (

        <div className="embed-responsive" style={styles.mapa}>
           <iframe  src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d486364.66200243676!2d-63.01163445!3d-17.757642900000004!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x93f1e81ca7c01a63%3A0x5c8b0a53a467611b!2sSanta%20Cruz%20de%20la%20Sierra!5e0!3m2!1ses-419!2sbo!4v1653891082933!5m2!1ses-419!2sbo" width={"100%"} height={"100%"}></iframe>
        </div>

    )
    
  }

}

export default Mapa;