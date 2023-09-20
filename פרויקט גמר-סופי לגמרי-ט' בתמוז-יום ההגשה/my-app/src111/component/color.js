import React, { useEffect, useState } from "react";

export default function Color(){
    const [Timer, setTimer] = new useState(0);
    const colors=['red','blue','pink','green','pink','yellow','ActiveBorder']
    function tick() {
        setTimer(v => v + 1);
    }
    useEffect(() => {
        const Timer1 = setInterval(tick, 1000);
    }, [])
    
    return( <>
        <div style={{backgroundColor:colors[Timer%5]}}> - </div>
    </>
    )
}