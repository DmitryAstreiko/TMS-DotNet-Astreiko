import React, { useState } from 'react'
import './index.css'
//import Buttons from './Buttons'

function resetValue() {
    const fName = document.querySelector("first-name")
    
}



function ValidateForm() {
    const [firstNameValue, setFirstNameValue] = useState('')

    return (
    
        <div className="validate-content">
            <h3 style={{textAlign: 'center'}}>Registration information</h3>            
            <div><label>First Name:</label></div>
            <div><input value={firstNameValue} className="text-validate" id="first-name" type="text" placeholder='First name'/></div>
            <div><label>Last Name:</label></div>
            <div><input className="text-validate" id="last-name" type="text" placeholder='Last name'/></div>
            <div><label>Password:</label></div>
            <div><input className="text-validate" id="password" type="text" placeholder='Password'/></div>
            <div>
                <label>Accept terms and conditions.</label>
                <input type="checkbox" id="accept"></input>
            </div>
            <div className="buttons-section">
            <button type="submit" className="button-validate">Submit</button>
            <button className="button-validate" onReset={resetValue()}>Cancel</button>
        </div>
        </div>
    )
}

export default ValidateForm