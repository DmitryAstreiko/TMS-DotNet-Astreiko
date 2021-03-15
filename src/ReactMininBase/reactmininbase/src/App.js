import TodoList from './todo/TodoList'

function App() {
  const todos = [
    {id: 1, completed: false, title: 'Buy bread'},
    {id: 2, completed: false, title: 'Buy butter'},
    {id: 3, completed: false, title: 'Buy milk'}
  ] 

  return (<div className="wrapper">
    <h1>React tutorial</h1>

    <TodoList todos={todos} />
  </div>)
}

export default App
