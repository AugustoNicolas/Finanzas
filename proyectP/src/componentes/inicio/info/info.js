import React from "react";
import fondito from "../../img/info.jpg"

const styles = {
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
        color:'black',
    },
    h1:{
        textAlign:'center',
        fontFamily: 'Segoe UI, Tahoma, Geneva, Verdana, sans-serif',
        fontWeight: 'bolder',
    },
    pa:{
        textAlign:'center',
    },
    textos:{
        display:'flex',
        flexDirection:'column',
        maxWidth:'550px',
    }
  }

class Info extends React.Component{
    render(){
        return(
            <div class="card text-dark" style={styles.contenedor}>
                <img class="card-img" src={fondito} alt="Card image"/>
                <div class="card-img-overlay" style={styles.parrafo}>
                    <div style={styles.textos}>
                        <h1 class="card-title" style={styles.h1}>¡Financia tu dinero de la mejor manera!</h1>
                        <p class="card-text" style={styles.pa}>¡Con nuestra página no volverás a perder las cuentas!, registrate y se parte de nuestra comunidad. Podrás realizar muchas funciones, ¡no te lo pierdas! MyMoney, llevando tus finanzas al siguiente nivel</p>
                    </div>
                </div>
            </div>
        )
    }
}
export default Info;