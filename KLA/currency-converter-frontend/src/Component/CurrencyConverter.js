import React, { useState } from 'react';
import axios from 'axios';

const CurrencyConverter = ({ onConvert }) => {
    const [amount, setAmount] = useState('');

    const handleConvert = async () => {
        try {
            const response = await axios.get(`http://localhost:5001/api/currencyconverter?amount=${amount}`);
            onConvert(`In words: ${response.data}`);
        } catch (error) {
            console.error('Error converting amount:', error);

            if (error.response && error.response.data) {
                const errorMessage = error.response.data;
                onConvert(`Error: ${errorMessage}`);
            } else {
                onConvert('Error: Unknown error occurred');
            }
           
        }
    };

    return (
        <div>
            <label>Enter amount:</label>
            <input type="text" value={amount} onChange={(e) => setAmount(e.target.value)} />
            <button onClick={handleConvert}>Convert</button>
        </div>
    );
};

export default CurrencyConverter;
