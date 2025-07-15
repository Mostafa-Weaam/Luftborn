import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import ItemList from './components/ItemList';
import ItemForm from './components/ItemForm';
import './App.css';

function App() {
  return (
    <Router>
      <div className="App">
        <header className="App-header">
          <h1>Item Manager</h1>
        </header>
        <main>
          <Routes>
            <Route path="/" element={<ItemList />} />
            <Route path="/create" element={<ItemForm />} />
            <Route path="/edit/:id" element={<ItemForm />} />
          </Routes>
        </main>
      </div>
    </Router>
  );
}

export default App;
