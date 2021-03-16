import React from 'react'
import './index.css'

function ValidateForm() {
    return (
        <div className="validate-content">
            <h3 style={{textAlign: 'center'}}>Registration information</h3>            
            <div><label>First Name:</label></div>
            <div><input className="text-validate" type="text" placeholder='First name'/></div>
            <div><label>Last Name:</label></div>
            <div><input className="text-validate" type="text" placeholder='Last name'/></div>
            <div><label>Password:</label></div>
            <div><input className="text-validate" type="text" placeholder='Password'/></div>
            <div>
                <label>Accept terms and conditions.</label>
                <input type="checkbox"></input>
            </div>
            <div className="buttons-section">
                <button className="button-validate">Submit</button>
                <button className="button-validate">Cancel</button>
            </div>
        </div>
    )
}

export default ValidateForm