import React, { useState, useEffect } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import { CreateItemRequest, UpdateItemRequest } from '../types/Item';
import { itemService } from '../services/api';
import './ItemForm.css';

const ItemForm: React.FC = () => {
  const navigate = useNavigate();
  const { id } = useParams<{ id: string }>();
  const isEditing = !!id;

  const [formData, setFormData] = useState({
    title: '',
    description: '',
  });
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    if (isEditing && id) {
      loadItem(id);
    }
  }, [isEditing, id]);

  const loadItem = async (itemId: string) => {
    try {
      setLoading(true);
      setError(null);
      const item = await itemService.getById(itemId);
      setFormData({
        title: item.title,
        description: item.description,
      });
    } catch (err) {
      setError('Failed to load item');
      console.error('Error loading item:', err);
    } finally {
      setLoading(false);
    }
  };

  const handleChange = (e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) => {
    const { name, value } = e.target;
    setFormData(prev => ({
      ...prev,
      [name]: value,
    }));
  };

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    
    if (!formData.title.trim()) {
      setError('Title is required');
      return;
    }

    try {
      setLoading(true);
      setError(null);

      if (isEditing && id) {
        const updateData: UpdateItemRequest = {
          id,
          title: formData.title,
          description: formData.description,
        };
        await itemService.update(id, updateData);
      } else {
        const createData: CreateItemRequest = {
          title: formData.title,
          description: formData.description,
        };
        await itemService.create(createData);
      }

      navigate('/');
    } catch (err) {
      setError(isEditing ? 'Failed to update item' : 'Failed to create item');
      console.error('Error submitting form:', err);
    } finally {
      setLoading(false);
    }
  };

  const handleCancel = () => {
    navigate('/');
  };

  if (loading && isEditing) {
    return <div className="loading">Loading item...</div>;
  }

  return (
    <div className="form-container">
      <div className="form-header">
        <h1>{isEditing ? 'Edit Item' : 'Create New Item'}</h1>
      </div>

      {error && (
        <div className="error-message">{error}</div>
      )}

      <form onSubmit={handleSubmit} className="item-form">
        <div className="form-group">
          <label htmlFor="title">Title *</label>
          <input
            type="text"
            id="title"
            name="title"
            value={formData.title}
            onChange={handleChange}
            required
            disabled={loading}
            placeholder="Enter item title"
          />
        </div>

        <div className="form-group">
          <label htmlFor="description">Description</label>
          <textarea
            id="description"
            name="description"
            value={formData.description}
            onChange={handleChange}
            disabled={loading}
            placeholder="Enter item description"
            rows={4}
          />
        </div>

        <div className="form-actions">
          <button
            type="button"
            onClick={handleCancel}
            className="cancel-button"
            disabled={loading}
          >
            Cancel
          </button>
          <button
            type="submit"
            className="submit-button"
            disabled={loading}
          >
            {loading ? 'Saving...' : (isEditing ? 'Update' : 'Create')}
          </button>
        </div>
      </form>
    </div>
  );
};

export default ItemForm;