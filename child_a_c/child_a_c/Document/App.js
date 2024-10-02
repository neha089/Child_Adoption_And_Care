// import React from 'react';
// import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
// import Home from './pages/Home';
// import StackPage from './pages/StackPage';
// import QueuePage from './pages/QueuePage';
// import LinkedListPage from './pages/LinkedListPage';

// function App() {
//   return (
//     <Router>
//       <Routes>
//         <Route path="/" element={<Home />} />
//         <Route path="/stack" element={<StackPage />} />
//         <Route path="/queue" element={<QueuePage />} />
//         <Route path="/linked-list" element={<LinkedListPage />} />
//       </Routes>
//     </Router>
//   );
// }

// export default App;
// import React from 'react';
// import './App.css';

// function App() {
//   return (
//     <div className="App">
//       <header className="App-header">
//         <h1>Welcome to Data Structures and Algorithms Visualization</h1>
//       </header>
//     </div>
//   );
// }

// export default App;


import React, { useEffect } from 'react';
import { BrowserRouter as Router, Route, Switch, useLocation } from 'react-router-dom';
import { Helmet } from 'react-helmet';
import Navbar from './components/Navbar';
import Footer from './components/Footer';
import Home from './components/Home';
import DataStructure from './components/DataStructure';
import PageNotFound from './components/PageNotFound';
import DsaMain from './components/DsaMain';
import InterviewQuestion from './components/InterviewQuestion';
import ProblemSolving from './components/ProblemSolving';

const usePageViews = () => {
  let location = useLocation();
  useEffect(() => {
    window.scrollTo(0, 0);
    // Update meta tags here if needed
  }, [location]);
};

const App = () => {
  usePageViews();
  return (
    <Router>
      <div>
        <Navbar />
        <Helmet>
          <title>Data Structures and Algorithms | Visualization</title>
          {/* Add other meta tags here */}
        </Helmet>
        <Switch>
          <Route exact path="/" component={Home} />
          <Route path="/data-structure" component={DataStructure} />
          <Route path="/interview-questions" component={InterviewQuestion} />
          <Route path="/problem-solving-trick" component={ProblemSolving} />
          <Route component={PageNotFound} />
        </Switch>
        <Footer />
      </div>
    </Router>
  );
};

export default App;
