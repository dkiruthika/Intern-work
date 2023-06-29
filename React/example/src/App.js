
import './App.css';

import { useState } from 'react';

const Hi = (props) =>{
  return (
    <div>hi here {props.num}</div>
  )
}
function App() {
  const [number,setNumber] = useState(0);
  const add = ()=>{
    setNumber(number+1);
  }
  return (
    <div className="App">
      <Hi num={number}/>
      <div>Number={number}</div>
      <button onClick={add}>add</button>
    </div>
  );
}

export default App;
