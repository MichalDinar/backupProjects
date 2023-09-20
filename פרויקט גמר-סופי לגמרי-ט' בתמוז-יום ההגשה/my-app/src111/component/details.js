import react from "react";

export default function Details(props) {

    return (<>
        <h1 style={{ color: "deeppink" }}>{props.r.name}</h1>
        ------------------------------
        <p>{props.r.pic}</p>  ------------------------------
        <p>describe:   {props.r.describe}</p>
        <p>rama:    {props.r.rama}</p>
        <p>time:    {props.r.time} min</p>
        <p>sog:    {props.r.sog}</p>
        <p>password:   {props.r.password}</p>
        <p style={{ color: "rebeccapurple" }}>---- 🛒:racivim:🛒----</p>
        <p>{props.r.raciv && props.r.raciv.map((r1) => {
            return <>
                <p style={{ color: "Highlight" }}> {r1.nameR} :  {r1.amount} </p>
            </>
        })
        } </p>

    </>)
}