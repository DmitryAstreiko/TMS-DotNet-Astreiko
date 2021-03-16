import React, {useEffect} from 'react'
import TodoList from './todo/TodoList'
import Context from './context'
//import AddTodo from './todo/AddTodo'
import Loader from './todo/Loader'
//import { func } from 'prop-types'
import Modal from './Modal/Modal'

const AddTodo = React.lazy(() => import('./todo/AddTodo'))

function App() {
  const [todos, setTodos] = React.useState([]) /*[
    {id: 1, completed: false, title: 'Buy bread'},
    {id: 2, completed: true, title: 'Buy butter'},
    {id: 3, completed: false, title: 'Buy milk'}
  ] )*/
  const [loading, setLoading] = React.useState(true)

  useEffect(() => {
    fetch('https://jsonplaceholder.typicode.com/todos?_limit=5')
      .then(response => response.json())
      .then(todos => {
        setTimeout(() => {
          setTodos(todos)
          setLoading(false)
        }, 2000)        
      })
  }, [])

  function toggleTodo(id) {
    setTodos(
      todos.map(todo => {
      if (todo.id === id) {
        todo.completed = !todo.completed
      }
      return todo
    })
    )
  }

  function removeTodo(id) {
    setTodos(todos.filter(todo => todo.id !== id))
  }

function addTodo(title) {
  setTodos(todos.concat([{
    title,
    id: Date.now(),
    completed: false
  }]))
}

  return (
    <Context.Provider value={{removeTodo}}>
    <div className="wrapper">
      <h1>React tutorial</h1>
      <Modal />

      <React.Suspense fallback={<p>Loading</p>}>
        <AddTodo onCreate={addTodo}></AddTodo> 
      </React.Suspense>
        
      

      {todos.length ? (
      <TodoList todos={todos} onToggle={toggleTodo}/> 
      ) :
      loading ? null : (<p>No todos!</p>
      )}      
    </div>
    </Context.Provider>
  )
}
//{loading && <Loader />}  --- insert into return allow (between <AddTodo onCreate={addTodo}></AddTodo> and  {todos.length ?...)

//<React.Suspense> working both const AddTodo = React.lazy(() => import('./todo/AddTodo'))

export default App
