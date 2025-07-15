import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import { Item } from '../types/Item';
import { itemService } from '../services/api';
import './ItemList.css';

const ItemList: React.FC = () => {
  const [items, setItems] = useState<Item[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    loadItems();
  }, []);

  const loadItems = async () => {
    try {
      setLoading(true);
      setError(null);
      const fetchedItems = await itemService.getAll();
      setItems(fetchedItems);
    } catch (err) {
      setError('Failed to load items');
      console.error('Error loading items:', err);
    } finally {
      setLoading(false);
    }
  };

  const handleDelete = async (id: string) => {
    if (window.confirm('Are you sure you want to delete this item?')) {
      try {
        await itemService.delete(id);
        setItems(items.filter(item => item.id !== id));
      } catch (err) {
        setError('Failed to delete item');
        console.error('Error deleting item:', err);
      }
    }
  };

  if (loading) {
    return <div className="loading">Loading items...</div>;
  }

  if (error) {
    return (
      <div className="error-container">
        <div className="error">{error}</div>
        <button onClick={loadItems} className="retry-button">
          Retry
        </button>
      </div>
    );
  }

  return (
    <div className="item-list-container">
      <div className="header">
        <h1>Items</h1>
        <Link to="/create" className="create-button">
          Create New Item
        </Link>
      </div>

      {items.length === 0 ? (
        <div className="empty-state">
          <p>No items found. <Link to="/create">Create your first item</Link></p>
        </div>
      ) : (
        <div className="items-grid">
          {items.map((item) => (
            <div key={item.id} className="item-card">
              <h3>{item.title}</h3>
              <p>{item.description}</p>
              <div className="item-actions">
                <Link to={`/edit/${item.id}`} className="edit-button">
                  Edit
                </Link>
                <button
                  onClick={() => handleDelete(item.id)}
                  className="delete-button"
                >
                  Delete
                </button>
              </div>
            </div>
          ))}
        </div>
      )}
    </div>
  );
};

export default ItemList;