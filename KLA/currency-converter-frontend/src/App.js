import React, { useState } from 'react';
import CurrencyConverter from './Component/CurrencyConverter';
import './App.css';

const App = () => {
    const [result, setResult] = useState('');

    const handleConvert = (convertedResult) => {
        setResult(convertedResult);
    };

    return (
        <div className="container">
            <h1 className="title">Currency Converter</h1>
            <CurrencyConverter onConvert={handleConvert} />
            <br></br><hr></hr>
            <p className="result">{result} </p>
        </div>
    );
};

export default App;
