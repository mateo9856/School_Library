import React from 'react';
import Icon from "./img/ErrorIcon.png";
import "./index.css";
const Error = () => {
    return (
        <div className = "errorBlock">
            <img className ="ErrorIcon" src={Icon} alt ="Error!" />
            <p style={{textAlign:"center", marginTop:"20px"}}>
            <h3>API ERROR!</h3>
            Api is not called!
            </p>
        </div>
    )
}
export default Error;