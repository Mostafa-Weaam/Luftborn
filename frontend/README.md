# Item Manager Frontend

A React TypeScript frontend application for managing items with full CRUD operations.

## Features

- **Create** new items with title and description
- **Read** and display all items in a grid layout
- **Update** existing items
- **Delete** items with confirmation
- Modern, responsive UI
- Error handling and loading states

## Technology Stack

- React 18 with TypeScript
- React Router for navigation
- Axios for API calls
- Modern CSS with responsive design

## Prerequisites

- Node.js 16 or higher
- npm or yarn package manager
- Backend API running (default: https://localhost:5001)

## Installation

1. Navigate to the frontend directory:
   ```bash
   cd frontend
   ```

2. Install dependencies:
   ```bash
   npm install
   ```

## Running the Application

1. Start the development server:
   ```bash
   npm start
   ```

2. Open your browser and navigate to `http://localhost:3000`

## API Configuration

The frontend is configured to connect to the backend API at `https://localhost:5001/api`. If your backend runs on a different port, update the `API_BASE_URL` in `src/services/api.ts`.

## Available Scripts

- `npm start` - Runs the app in development mode
- `npm test` - Launches the test runner
- `npm run build` - Builds the app for production
- `npm run eject` - Ejects from Create React App (one-way operation)

## Usage

1. **View Items**: The main page displays all items in a grid layout
2. **Create Item**: Click "Create New Item" to add a new item
3. **Edit Item**: Click "Edit" on any item card to modify it
4. **Delete Item**: Click "Delete" on any item card to remove it (with confirmation)

## Project Structure

```
src/
├── components/          # React components
│   ├── ItemList.tsx    # Main list view
│   ├── ItemForm.tsx    # Create/Edit form
│   └── *.css           # Component styles
├── services/           # API service layer
│   └── api.ts         # HTTP requests
├── types/             # TypeScript interfaces
│   └── Item.ts        # Item model types
├── App.tsx            # Main app component
└── index.tsx          # Entry point
```

## Responsive Design

The application is fully responsive and works well on:
- Desktop screens
- Tablets
- Mobile devices

## Error Handling

The application includes comprehensive error handling for:
- Network errors
- API failures
- Loading states
- Form validation
