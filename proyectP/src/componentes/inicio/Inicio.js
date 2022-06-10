import React from 'react';

import Menu from '../menu/Menu';
import Footer from '../footer/Footer';
import Slider from './slider/Slider';
import Services from './services/Services'; 
import Info from './info/info';
import Advice from './advice/Advice';

class Home extends React.Component {
 
    render() {
    
    return(
        <>
        <Menu /> 
        <main role="main" className="flex-shrink">
            <div className="containe-fluid">
                <Slider /> 
                <Info />
                <Advice/>
                <hr className="featurette-divider" />
                <Services /> 

                <hr className="featurette-divider" />
            </div>

        </main>
    
       <Footer />
    
       </>
    
        )
    
    }
    
   }

   export default Home;