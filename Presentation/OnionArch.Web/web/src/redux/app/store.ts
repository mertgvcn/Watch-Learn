import { configureStore } from '@reduxjs/toolkit'
import { useDispatch } from 'react-redux'
//reducers
import courseReducer from '../features/course/courseSlice'
import currentStudentReducer  from '../features/currentStudent/currentStudentSlice'

export const store = configureStore({
    reducer: {
        course: courseReducer,
        currentStudent: currentStudentReducer
    },
})

export type RootState = ReturnType<typeof store.getState>

type AppDispatch = typeof store.dispatch
export const useAppDispatch = useDispatch.withTypes<AppDispatch>()