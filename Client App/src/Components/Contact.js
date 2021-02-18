import React from 'react';
import "../styles/Contact.css";

function Contact() {
    return (
    <React.Fragment>
            <h1 className ="workDaysHeader">Our libaries works in given hours and days</h1>
            <ul className = "workDays">
                <li>
                    <b>Monday - Friday</b> : 08:00 - 17:00 
                </li>
                <li>
                    <b>Saturday</b> : 09:00 - 14:00
                </li>
            </ul>
            <div className = "address">
            <h2>Libary address</h2>
            <p><b>Lublin</b>, ul.Okopowa 900</p>
            <p><b>E-mail</b>: lublinLibary900@gmail.com</p>
            </div>
            <div className ="socialMedia">
                <h1 className ="workDaysHeader">Social media</h1>
                <div className = "flexMedia">
                    <button><ion-icon name="logo-facebook"></ion-icon></button>
                    <button><ion-icon name="logo-twitter"></ion-icon></button>
                    <button><ion-icon name="logo-instagram"></ion-icon></button>
                </div>
            </div>
    </React.Fragment>
    )
}

export default Contact;