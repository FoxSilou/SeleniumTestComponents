using System;

namespace SeleniumTestComponents.BaseComponents.Base
{
    public class BaseAction<S, F>
    {
        protected S _returnedSuccessPage;
        protected Action _successAction;
        protected F _returnedFailPage;
        protected Action _failAction;

        public BaseAction(S returnedSuccessPage, F returnedFailPage, Action successAction = null, Action failAction = null)
        {
            _returnedSuccessPage = returnedSuccessPage;
            _successAction = successAction;
            _returnedFailPage = returnedFailPage;
            _failAction = failAction;
        }

        public S ShouldSucceed()
        {
            _successAction?.Invoke();
            return _returnedSuccessPage;
        }

        public F ShouldFail()
        {
            _failAction?.Invoke();
            return _returnedFailPage;
        }
    }

    public class BaseAction<R> : BaseAction<R, R>
    {
        public BaseAction(R returnedPage, Action successAction = null, Action failAction = null)
            : base(returnedPage, returnedPage, successAction, failAction)
        {
        }
    }

    public class BaseAction
    {
        public static BaseAction<S, F> New<S, F>(S returnedSuccessPage, F returnedFailPage, Action successAction = null, Action failAction = null)
        { 
            return new BaseAction<S, F>(returnedSuccessPage, returnedFailPage, successAction, failAction); 
        }

        public static BaseAction<R> New<R>(R returnedPage, Action successAction = null, Action failAction = null)
        {
            return new BaseAction<R>(returnedPage, successAction, failAction);
        }
    }
}
