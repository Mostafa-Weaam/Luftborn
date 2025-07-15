import React, { useState, useEffect } from 'react';
import { Item } from './types/Item';
import { getAllItems } from './services/itemService';
import ItemList from './components/ItemList';
import ItemForm from './components/ItemForm';
import './App.css';

const App: React.FC = () => {
  const [items, setItems] = useState<Item[]>([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);
  const [showForm, setShowForm] = useState(false);
  const [editingItem, setEditingItem] = useState<Item | null>(null);

  // Load items on component mount
  useEffect(() => {
    loadItems();
  }, []);

  const loadItems = async () => {
    setLoading(true);
    setError(null);
    try {
      const fetchedItems = await getAllItems();
      setItems(fetchedItems);
    } catch (err) {
      setError(err instanceof Error ? err.message : 'Failed to load items');
    } finally {
      setLoading(false);
    }
  };

  const handleCreateClick = () => {
    setEditingItem(null);
    setShowForm(true);
  };

  const handleEdit = (item: Item) => {
    setEditingItem(item);
    setShowForm(true);
  };

  const handleSave = (item: Item) => {
    if (editingItem) {
      // Update existing item
      setItems(items.map(i => i.id === item.id ? item : i));
    } else {
      // Add new item
      setItems([...items, item]);
    }
    setShowForm(false);
    setEditingItem(null);
  };

  const handleDelete = (id: string) => {
    setItems(items.filter(item => item.id !== id));
  };

  const handleCancel = () => {
    setShowForm(false);
    setEditingItem(null);
  };

  return (
    <div className="app">
      <header className="app-header">
        <h1>Item Management System</h1>
        <p>A React.js frontend with CRUD operations</p>
      </header>

      <main className="app-main">
        <div className="app-actions">
          <button 
            onClick={handleCreateClick}
            className="btn btn-primary"
            disabled={loading}
          >
            + Create New Item
          </button>
          <button 
            onClick={loadItems}
            className="btn btn-secondary"
            disabled={loading}
          >
            🔄 Refresh
          </button>
        </div>

        {showForm && (
          <div className="form-container">
            <ItemForm
              item={editingItem}
              onSave={handleSave}
              onCancel={handleCancel}
            />
          </div>
        )}

        <div className="content-container">
          <ItemList
            items={items}
            loading={loading}
            error={error}
            onEdit={handleEdit}
            onDelete={handleDelete}
          />
        </div>
      </main>

      <footer className="app-footer">
        <p>© 2024 Item Management System. Built with React.js and TypeScript.</p>
      </footer>
    </div>
  );
};

export default App;
