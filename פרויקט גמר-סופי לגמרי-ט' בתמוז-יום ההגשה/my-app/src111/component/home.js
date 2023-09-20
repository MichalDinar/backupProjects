import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import pic1 from '../assets/ריבועי.PNG'
import Color from "./color";

export default function Home() {

    const n = useNavigate()

    return (<>
    <Color></Color>
        <div class="topnav">
            <h1 style={{ color: "white" }}> ברוכים הבאים לאתר המדהים שלנו</h1>
            <h1 style={{ color: "white" }}>🍧🍷🥰🍫🧆🍮🥞🎂🍩אתר המתכונים🍬🍡🍭👨🏻‍🤝‍👨🏻🍓🍁🌴🌵🍕</h1>
        </div>
        <Color></Color>
        <button type="submit" style={{ margin: "2%" }} onClick={() => n("/myNav/myRegister")}>  הרשמה </button>
        <button type="submit" style={{ margin: "2%" }} onClick={() => n("/myRecipy")}>  אורח </button>
        <button type="submit" style={{ margin: "2%" }} onClick={() => n("/myNav/myLogin")}>  לקוח </button>
        <br></br><br></br>
        <img style={{height:"350px",width:"400px",float:"left"}} src={pic1}></img>
        <img style={{height:"350px",width:"400px"}} src={pic1}></img>
        <img style={{height:"350px",width:"400px",float:"right"}} src={pic1}></img>
    </>)
}
