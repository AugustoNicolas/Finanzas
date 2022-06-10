import React from "react";
import imgadvice from "../../img/sadvice.jpg"

const styles={
    img:{
        imagerendering: 'optimizeQuality',
        position: 'relative',
        width: '100%',
        height: '100%',
    }  
}
class Advice extends React.Component{
    render(){
        return(
            <div >
                <img src={imgadvice} style={styles.img}></img>
            </div>
        )
    }
}

export default Advice;