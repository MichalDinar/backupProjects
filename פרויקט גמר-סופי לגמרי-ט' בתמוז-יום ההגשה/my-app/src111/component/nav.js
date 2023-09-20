import React from "react";
import { useSelector } from 'react-redux'
import { Link, Outlet } from "react-router-dom";
import Color from "./color";
import Login from "./login";
import Register from "./register";

export default function Nav(props) {

    const Manger = useSelector(state => state.userR.isManger)
    const name = useSelector(state => state.userR.user?.name)

    return (<>
        <Color></Color>
        <div class="topnav">
            <h1 style={{ color: "white" }}> ברוכים הבאים לאתר המדהים שלנו</h1>
            <h1 style={{ color: "white" }}>🍧🍷🥰🍫🧆🍮🥞🎂🍩אתר המתכונים🍬🍡🍭👨🏻‍🤝‍👨🏻🍓🍁🌴🌵🍕</h1>
           
            {!name && <>
                <a><Link to="/myNav/myLogin">התחבר</Link></a>
                <a><Link to="/myNav/myRegister">הרשמה</Link></a>
            </>
            }
            {name  && !Manger && <>
                <h4 style={{color:"white"}}>שלום  {name}</h4>
               <a><Link to="/myNav/myAddRecipy">הוסף מתכון</Link></a>
               <a><Link to="/myNav/myRecipy"> צפייה במתכונים</Link></a>
               <a><Link to="/myNav/RecipyListPersonal"> צפייה במתכונים באזור האישי</Link></a>
               <a><Link to="/myNav/myRecipyAdd">צפייה במתכונים שהוספתי</Link></a>
               </>
            }
            {Manger && <>
                <h4 style={{color:"white"}}>שלום  {name}</h4>
                <a><Link to="/myNav/myRecipy"> צפייה במתכונים</Link></a>
                <a><Link to="/myNav/myUsers"> צפיה במשתמשים</Link></a>
            </>
            }
        </div>
        <Color></Color>
        <br></br><br></br>
        {props.l == "לקוח" &&
            <Login></Login>
        }
        {props.l == "הרשמה" &&
            <Register></Register>
        }
        <Outlet />
    </>
    )
}
