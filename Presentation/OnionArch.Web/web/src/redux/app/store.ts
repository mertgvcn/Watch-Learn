import { configureStore } from '@reduxjs/toolkit'
import { useDispatch } from 'react-redux'
//reducers
import courseReducer from '../features/course/courseSlice'
import studentReducer  from '../features/student/studentSlice'

export const store = configureStore({
    reducer: {
        course: courseReducer,
        student: studentReducer
    },
})

export type RootState = ReturnType<typeof store.getState>

type AppDispatch = typeof store.dispatch
export const useAppDispatch = useDispatch.withTypes<AppDispatch>()