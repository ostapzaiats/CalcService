import React, {useState} from 'react';
import axios from 'axios';
import logo from './logo.svg';
import './App.css';

function App() {
  const [num1, setNum1] = useState('');
  const [num2, setNum2] = useState('');
  const [result, setResult] = useState('');

  const handleCalculate = async () => {
    try {
      const response = await axios.post('http://localhost:8080/add', { num1: num1, num2: num2 });
      setResult(response.data);
    } catch(error) {
      console.log('Error:', error);
    }
  }

  return (
    <div>
      <input type="number" value={num1} onChange={(e) => setNum1(e.target.value)} />
      <input type="number" value={num2} onChange={(e) => setNum2(e.target.value)} />

      <button onClick={handleCalculate}>Calculate</button>

      {result && <div>Result: {result}</div>}
    </div>
  );
}

export default App;
