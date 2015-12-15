
;;;========================================================
;;;     Suppermarket Supply Expert System
;;;		
;;;		Expert system ini memberikan luaran berupa
;;;		rekomendasi suplai barang atau tidak
;;;
;;;     CLIPS Version 6.3
;;;
;;;     For use with the Supermarket Supply Support System
;;;========================================================

;;; ***************************
;;; * DEFTEMPLATES & DEFFACTS *
;;; ***************************

(deftemplate UI-state
   (slot id (default-dynamic (gensym*)))
   (slot display)
   (slot relation-asserted (default none))
   (slot response (default none))
   (multislot valid-answers)
   (slot state (default middle)))
   
(deftemplate state-list
   (slot current)
   (multislot sequence))
  
(deffacts startup
   (state-list))


;;;****************
;;;* STARTUP RULE *
;;;****************

(defrule system-banner ""

  =>
  
  (assert (UI-state (display WelcomeMessage)
                    (relation-asserted start)
                    (state initial)
                    (valid-answers))))

;;;***************
;;;* QUERY RULES *
;;;***************

(defrule determine-willing-to-supply ""

   (logical (start))

   =>

   (assert (UI-state (display StartQuestion)
                     (relation-asserted consult-start)
                     (response Tidak)
                     (valid-answers Tidak Ya))))

(defrule determine-willing-to-supply-yes ""

   (logical (consult-start Ya))

   =>

   (assert (UI-state (display GeneralEconomicQuestion)
                     (relation-asserted willing-supply)
                     (response Baik)
                     (valid-answers Baik Sedang Buruk))))

(defrule determine-willing-to-supply-no ""

   (logical (consult-start Tidak))

   =>

   (assert (UI-state (display NoSupplyResult)
                     (state final)))

(defrule determine-general-economic-good ""

   (logical (engine-starts Baik))

   =>

   (assert (UI-state (display RainyQuestion)
                     (relation-asserted rainy-season)
                     (response Tidak)
                     (valid-answers Tidak Ya))))

(defrule determine-general-economic-bad ""

   (logical (engine-starts Buruk))

   =>

   (assert (UI-state (display RainyQuestion)
                     (relation-asserted rainy-season)
                     (response Tidak)
                     (valid-answers Tidak Ya))))

(defrule determine-general-economic-medium ""

   (logical (engine-starts Sedang))

   =>

   (assert (UI-state (display RainyQuestion)
                     (relation-asserted rainy-season)
                     (response Tidak)
                     (valid-answers Tidak Ya))))

(defrule determine-rainy-season-yes ""

   (logical (rainy-season Ya))

   =>

   (assert (UI-state (display ClosestEventQuestion)
                     (relation-asserted closest-event)
                     (response NoEven)
                     (valid-answers NoEven Puasa Lebaran IdulAdha Natal LiburanSekolah TahunBaru))))

(defrule determine-rainy-season-no ""

   (logical (rainy-season Tidak))

   =>

   (assert (UI-state (display ClosestEventQuestion)
                     (relation-asserted closest-event)
                     (response NoEven)
                     (valid-answers NoEven Puasa Lebaran IdulAdha Natal LiburanSekolah TahunBaru))))

(defrule determine-closest-event-noevent ""

   (logical (closest-event NoEvent))

   =>

   (assert (UI-state (display SupermarketEcoQuestion)
                     (relation-asserted supermarket-eco)
                     (response Baik)
                     (valid-answers Baik Sedang Buruk))))

(defrule determine-closest-event-puasa ""

   (logical (closest-event Puasa))

   =>

   (assert (UI-state (display SupermarketEcoQuestion)
                     (relation-asserted supermarket-eco)
                     (response Baik)
                     (valid-answers Baik Sedang Buruk))))

(defrule determine-closest-event-lebaran ""

   (logical (closest-event Lebaran))

   =>

   (assert (UI-state (display SupermarketEcoQuestion)
                     (relation-asserted supermarket-eco)
                     (response Baik)
                     (valid-answers Baik Sedang Buruk))))

(defrule determine-closest-event-iduladha ""

   (logical (closest-event IdulAdha))

   =>

   (assert (UI-state (display SupermarketEcoQuestion)
                     (relation-asserted supermarket-eco)
                     (response Baik)
                     (valid-answers Baik Sedang Buruk))))

(defrule determine-closest-event-natal ""

   (logical (closest-event Natal))

   =>

   (assert (UI-state (display SupermarketEcoQuestion)
                     (relation-asserted supermarket-eco)
                     (response Baik)
                     (valid-answers Baik Sedang Buruk))))

(defrule determine-closest-event-liburan ""

   (logical (closest-event LiburanSekolah))

   =>

   (assert (UI-state (display SupermarketEcoQuestion)
                     (relation-asserted supermarket-eco)
                     (response Baik)
                     (valid-answers Baik Sedang Buruk))))

(defrule determine-closest-event-tahunbaru ""

   (logical (closest-event TahunBaru))

   =>

   (assert (UI-state (display SupermarketEcoQuestion)
                     (relation-asserted supermarket-eco)
                     (response Baik)
                     (valid-answers Baik Sedang Buruk))))

(defrule determine-supermarket-eco-baik ""

   (logical (supermarket-eco Baik))

   =>

   (assert (UI-state (display ResultDisplay)
                     (state final))))

(defrule determine-supermarket-eco-buruk ""

   (logical (supermarket-eco Buruk))

   =>

   (assert (UI-state (display ResultNoDisplay)
                     (state final))))

(defrule determine-supermarket-eco-sedang ""

   (logical (supermarket-eco Sedang))

   =>

   (assert (UI-state (display ResultDisplay)
                     (state final))))