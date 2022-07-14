namespace UnityEngine.EventSystems
{
    /// <summary>
    /// Base behaviour that has protected implementations of Unity lifecycle functions.
    /// </summary>
    public abstract class UIBehaviour : MonoBehaviour
    {
        protected virtual void Awake()
        {}

        protected virtual void OnEnable()
        {}

        protected virtual void Start()
        {}

        protected virtual void OnDisable()
        {}

        protected virtual void OnDestroy()
        {}

        /// <summary>
        /// Returns true if the GameObject and the Component are active.
        /// </summary>
        public virtual bool IsActive()
        {
            return isActiveAndEnabled;
        }

#if UNITY_EDITOR//只在编辑器模式下会被调用
        protected virtual void OnValidate()//当脚本被加载（禁用或启动）或者Inspector面板的值出现变化的时候调用
        {}

        protected virtual void Reset()//将脚本恢复为默认值时调用
        {}
#endif
        /// <summary>
        /// This callback is called if an associated RectTransform has its dimensions changed. The call is also made to all child rect transforms, even if the child transform itself doesn't change - as it could have, depending on its anchoring.
        /// </summary>
        protected virtual void OnRectTransformDimensionsChange()//当RectTransform变化时调用，Anchors、Pivot、Width、Height变化时调用，Transform、Rotation、Scale变化时不调用
        {}

        protected virtual void OnBeforeTransformParentChanged()//当父物体变化之前调用
        {}

        protected virtual void OnTransformParentChanged()//当父物体变化之后调用
        { }

        protected virtual void OnDidApplyAnimationProperties()//当应用动画属性时调用
        {}

        protected virtual void OnCanvasGroupChanged()//当Canvas Group变化时调用
        {}

        /// <summary>
        /// Called when the state of the parent Canvas is changed.
        /// </summary>
        protected virtual void OnCanvasHierarchyChanged()//当Canvas状态变化时调用，比如禁用Canvas组件
        {}

        /// <summary>
        /// Returns true if the native representation of the behaviour has been destroyed.
        /// </summary>
        /// <remarks>
        /// When a parent canvas is either enabled, disabled or a nested canvas's OverrideSorting is changed this function is called. You can for example use this to modify objects below a canvas that may depend on a parent canvas - for example, if a canvas is disabled you may want to halt some processing of a UI element.
        /// </remarks>
        public bool IsDestroyed()
        {
            // Workaround for Unity native side of the object
            // having been destroyed but accessing via interface
            // won't call the overloaded ==
            return this == null;
        }
    }
}
