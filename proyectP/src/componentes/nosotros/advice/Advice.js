import React from "react";
import imgadvice from "../../img/advice2.jpg"

const styles={
    img:{
        imagerendering: 'optimizeQuality',
        position: 'relative',
        width: '100%',
        height: '100%',
        
    },
    contenedor:{
    }
}
class Advice extends React.Component{
    render(){
        return(
            <div style={styles.contenedor}>
                <img src={imgadvice} style={styles.img} class="img" ></img>
            </div>
        )
    }
}

export default Advice;